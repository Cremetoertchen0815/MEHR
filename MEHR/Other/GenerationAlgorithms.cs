﻿using MEHR.Contexts;
using MEHR.Models;
using MEHR.Other;
using Microsoft.EntityFrameworkCore;

namespace MEHR;

public static class GenerationAlgorithms
{
    /// <summary>
    /// Filters all FoodLocations in the database for the specified query and sorts it by distance from the user.
    /// </summary>
    /// <param name="query">User query(filter options input by the user)</param>
    /// <param name="locLat">The latitude of the user position(coordinate).</param>
    /// <param name="locLong">The longitude of the user position(coordinate).</param>
    /// <param name="context">The database context for accessing data.</param>
    public static List<FoodLocation> QueryFoodFinder(FoodFinderQuery query, double locLat, double locLong, DataContext context) =>
        //Query all food locations from the database
        context.FoodLocations.Include(x => x.Foods!).ThenInclude(x => x.Tag).AsEnumerable()
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


    public static List<FoodLocation>? QueryFoodPlanner(FoodPlannerQuery query, ulong userID, double locLat, double locLong, DataContext context)
    {
        var foods = context.FoodLocations.AsEnumerable();
        var user = context.Users.Include(x => x.History!).ThenInclude(x => x.Location).FirstOrDefault(x => x.CookieHash == userID);
        if (user == null) return null;
        var history = user.History!.OrderByDescending(x => x.CreationDate).Take(10).ToList();

    }
}
