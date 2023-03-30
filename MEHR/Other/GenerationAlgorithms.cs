using MEHR.Contexts;
using MEHR.Models;
using Microsoft.EntityFrameworkCore;

namespace MEHR;

public static class GenerationAlgorithms
{
    public const int FOOD_PLANNER_HISTORY_SAMPLES = 10;
    public const int FOOD_PLANNER_ELEMENTS = 5;

    /// <summary>
    /// Filters all FoodLocations in the database for the specified query and sorts it by distance from the user.
    /// </summary>
    /// <param name="query">User query(filter options input by the user)</param>
    /// <param name="locLat">The latitude of the user position(coordinate).</param>
    /// <param name="locLong">The longitude of the user position(coordinate).</param>
    /// <param name="context">The database context for accessing data.</param>
    public static List<FoodLocation> QueryFoodFinder(FoodFinderQuery query, double locLat, double locLong, DataContext context) =>
        //Query all food locations from the database
        context.FoodLocations.Include(x => x.Foods!).ThenInclude(x => x.Tag).Include(x => x.Ratings).AsEnumerable()
            //Calculate distance to user for each and convert to Enumeration of Tuple(FoodLocation, DistanceToUser)
            .Select(x => ((FoodLocation Item, double DistanceToUser))
                    (x, HelperAPIs.GetLocationBetweenCoords(locLat, locLong, x.LocationLatitude, x.LocationLongitude)))
            //Filter food locations by user query
            .Where(x =>
            {
                //Query parameters all have an ignore state, which if set, the parameter can be ignored and is always true
                var distanceParam = query.MaxDistanceInKM is null || x.DistanceToUser <= query.MaxDistanceInKM; // Ignore state: null
                var costParam = query.MaxPriceInEUR is null || x.Item.Foods!.Min(x => x.LowerPriceRange) <= query.MaxPriceInEUR; // Ignore state: null
                var tagsParam = query.AssociatedTags.Count == 0 || x.Item.Foods!.Any(x => query.AssociatedTags.Contains(x.Tag?.Name ?? string.Empty)); // Ignore state: list empty
                var openParam = !query.CurrentlyOpen || x.Item.OpeningTimes.IsOpenAt(DateTime.Now); // Ignore state: false
                var deliveryParam = !query.IsDeleviring || x.Item.HasDelivery; // Ignore state: false
                //Filter holds true when all parameters are true, so are either ignored or hold true
                return distanceParam && costParam && tagsParam && openParam && deliveryParam;
            })
            //Sort by distance to the user
            .OrderBy(x => x.DistanceToUser)
            //Filter out distance again to receive pure FoodLocation List, execute LINQ query by converting to list and return said list
            .Select(x => x.Item).ToList();

    //Ideas for FoodPlanner algorithm:
    // 1. Calculate average score for all users and the specific user, if user scores are empty => reg score; if reg score empty => 5/10
    // 2. Linearly interpolate(Lerp) between both values with the ExternalInfluence factor
    // 3. Check if location is in history (else factor is 0) and calculate the reoccurence factor by the formula of (1 - IndexInHistory / SampleCount) (Index of 0 is the most recent)
    // 3. Multiply each list value with (1 - Diversity * ReoccurenceFactor)
    // 4. Normalize list against the sum & Clamp to 01
    // 5. Use area conquer algorithm with random samples to generate result
    // 6. Store result in order to history list

    public static List<FoodLocation>? QueryFoodPlanner(FoodPlannerQuery query, ulong userID, double locLat, double locLong, DataContext context)
    {
        //Fetch user data + history from db
        if (context.Users.FirstOrDefault(x => x.CookieHash == userID) is not AppUser user) return null;
        var history = context.HistoryItems.Where(x => x.Owner.Id == user.Id).OrderByDescending(x => x.CreationDate)
                                            .Select(x => x.Location.Id).Take(FOOD_PLANNER_HISTORY_SAMPLES).ToList()!;
        // Fetch all foods and filter by query
        var locations = context.FoodLocations.Include(x => x.Ratings!).ThenInclude(x => x.Author)
                                             .Include(x => x.Foods!).ThenInclude(x => x.Tag).AsEnumerable().Where(x =>
            {
                var distance = HelperAPIs.GetLocationBetweenCoords(locLat, locLong, x.LocationLatitude, x.LocationLongitude);
                //Query parameters all have an ignore state, which if set, the parameter can be ignored and is always true
                var distanceParam = query.MaxDistanceInKM is null || distance <= query.MaxDistanceInKM; // Ignore state: null
                var costParam = query.MaxPriceInEUR is null || x.Foods!.Min(x => x.LowerPriceRange) <= query.MaxPriceInEUR; // Ignore state: null
                //Filter holds true when all parameters are true, so are either ignored or hold true
                return distanceParam && costParam;
            }).ToArray();

        //Clear history to prevent build up
        context.RemoveRange(context.HistoryItems.Include(x => x.Owner).Where(x => x.Owner.Id == user.Id));

        return Enumerable.Range(0, FOOD_PLANNER_ELEMENTS).Select(_ =>
        {
            //Assign scores and order by said scores
            var locationScores = locations.Select(x =>
            {
                //Calculate ratings/influence factor
                var regScoreAvg = x.Ratings!.Select(y => (float)y.Rating).DefaultIfEmpty(5f).Average();
                var userScoreAvg = x.Ratings!.Where(y => y.Author!.Id == user.Id).Select(x => (float)x.Rating).DefaultIfEmpty(regScoreAvg).Average();
                var baseScore = Lerp(userScoreAvg, regScoreAvg, query.ExternalInfluence);

                //Calculate diversity factor
                var historyIndex = history.IndexOf(x.Id);
                if (historyIndex > -1)
                {
                    var reoccurenceFactor = 1 - (historyIndex + 0.1f) / FOOD_PLANNER_HISTORY_SAMPLES;
                    baseScore *= 1 - query.Diversity * reoccurenceFactor;
                }

                return ((FoodLocation Location, float Score))(x, baseScore);
            }).OrderByDescending(x => x.Score).ToList();

            //Normalize scores against the sum(ignore and clamp negative values)
            var invSumScore = 1 / locationScores.Sum(x => MathF.Max(x.Score, 0));
            locationScores = locationScores.Select(x => ((FoodLocation Location, float Score))(x.Location, Clamp01(x.Score * invSumScore))).ToList();

            //Area conquer algorithm
            FoodLocation GenerateResult()
            {
                var counter = 0f;
                var fieldIdx = Random.Shared.NextSingle();
                for (int i = 0; i < locationScores.Count - 1; i++)
                {
                    counter += locationScores[i].Score;
                    if (fieldIdx < counter) return locationScores[i].Location;
                }

                return locationScores.Last().Location;
            }
            
            //Generate result and save in history
            var result = GenerateResult();
            history.Insert(0, result.Id);
            context.HistoryItems.Add(new HistoryItem() { CreationDate = DateTime.Now.ToBinary(), Location = result, Owner = user });

            return result;
        }).ToList();
    }


    private static float Clamp01(float a) => MathF.Min(MathF.Max(a, 0.0f), 1f);
    private static float Lerp(float a, float b, float t) => a + (b - a) * Clamp01(t);
}
