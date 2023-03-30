using MEHR.Models;

namespace MEHR;

public record struct LocationInfo
(
    double LocationLatitude,
    double LocationLongitude,
    int Icon,
    string Name,
    string Description,
    string PhoneNumber,
    string Address,
    string OpeningTimesHTML,
    bool HasDelivery,
    FoodInfo[] Foods,
    RatingInfo[] Ratings
)
{
    public static LocationInfo FromFoodLocation(FoodLocation location) => new LocationInfo(location.LocationLatitude,
        location.LocationLongitude,
        location.Icon,
        location.Name ?? "-",
        location.Description ?? "-",
        location.PhoneNumber ?? "-",
        location.Address ?? "-",
        location.OpeningTimes.ToHtml(),
        location.HasDelivery,
        location.Foods?.Select(x => FoodInfo.FromFood(x)).ToArray() ?? Array.Empty<FoodInfo>(),
        location.Ratings?.Select(x => RatingInfo.FromRating(x)).ToArray() ?? Array.Empty<RatingInfo>());
}