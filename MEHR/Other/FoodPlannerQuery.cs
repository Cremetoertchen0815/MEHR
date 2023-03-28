namespace MEHR;

public record struct FoodPlannerQuery
(
    float Diversity,
    float ExternalInfluence,
    double? MaxDistanceInKM,
    decimal? MaxPriceInEUR
) { }
