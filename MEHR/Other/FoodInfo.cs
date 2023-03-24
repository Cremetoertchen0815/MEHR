using MEHR.Models;

namespace MEHR.Other;

public record struct FoodInfo
 (
    string? Name,
    decimal LowerPriceRange,
    decimal UpperPriceRange,
    string Tag
 )
{
    public static FoodInfo FromFood(Food food) => new FoodInfo(
        food.Name ?? "-",
        food.LowerPriceRange,
        food.UpperPriceRange,
        food.Tag?.Name ?? "-");
}
