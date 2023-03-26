namespace MEHR;

public record struct FoodPlannerQuery
(
    float Diversity,
    float ExternalInfluence,
    double? MaxPriceInEUR,
    decimal? MaxDistanceInKM
) { }
