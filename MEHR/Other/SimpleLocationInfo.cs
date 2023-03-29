using MEHR.Models;

namespace MEHR.Other;

public record struct SimpleLocationInfo
(
    double LocationLatitude,
    double LocationLongitude,
    int Icon,
    string Name,
    string Description,
    string PhoneNumber,
    bool HasDelivery,
    FoodInfo[] Foods,
    RatingInfo[] Ratings
)
{
    public static SimpleLocationInfo FromFoodLocation(FoodLocation location) => new SimpleLocationInfo(location.LocationLatitude,
        location.LocationLongitude,
        location.Icon,
        location.Name ?? "-",
        location.Description ?? "-",
        location.PhoneNumber ?? "-",
        location.HasDelivery,
        location.Foods?.Select(x => FoodInfo.FromFood(x)).ToArray() ?? Array.Empty<FoodInfo>(),
        location.Ratings?.Select(x => RatingInfo.FromRating(x)).ToArray() ?? Array.Empty<RatingInfo>());
}