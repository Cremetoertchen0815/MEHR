using MEHR.Models;

namespace MEHR;

public record struct FoodFinderQuery
(
    double? MaxDistanceInKM,
    decimal? MaxPriceInEuro,
    List<string>? AssociatedTags,
    bool CurrentlyOpen,
    bool IsDeleviring
) { }
