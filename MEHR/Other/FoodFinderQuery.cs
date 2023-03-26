namespace MEHR;

public record struct FoodFinderQuery
(
    double? MaxDistanceInKM,
    decimal? MaxPriceInEUR,
    List<string> AssociatedTags,
    bool CurrentlyOpen,
    bool IsDeleviring
)
{ }
