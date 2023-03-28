namespace MEHR;

public record struct FoodPlannerQuery
(
    float Diversity,
    float ExternalInfluence,
    decimal? MaxPriceInEUR,
    double? MaxDistanceInKM
) { }
