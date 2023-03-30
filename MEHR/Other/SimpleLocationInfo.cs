using MEHR.Models;

namespace MEHR.Other;

public record struct SimpleLocationInfo
(
    int Id,
    string Name,
    string Address,
    bool HasDelivery,
    string Tags,
    float AvrRating
)
{
    public static SimpleLocationInfo FromFoodLocation(FoodLocation location) => new SimpleLocationInfo(
        location.Id,
        location.Name ?? "-",
        location.Address ?? "-",
        location.HasDelivery,
        string.Join(", ", location.Foods!.Where(x => x?.Tag?.Name is not null).Select(x => x.Tag!.Name!).Distinct()),
        (float)Math.Round(location.Ratings?.Select(x => x.Rating).ToArray().Average() ?? 5d, 2));
}