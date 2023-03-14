using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEHR.Models;

public class FoodLocation
{
    public int Id { get; set; }
    public double LocationLatitude { get; set; }
    public double LocationLongitude { get; set; }
    public int Icon { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public bool HasDelivery { get; set; }
    public ICollection<Food>? Foods { get; set; }
    public ICollection<LocationRating>? Ratings { get; set; }

    public string OpeningTimesSerial
    {
        get => JsonConvert.SerializeObject(OpeningTimes);
        set => OpeningTimes = JsonConvert.DeserializeObject<OpeningTimes>(value);
    }

    [NotMapped]
    public OpeningTimes OpeningTimes { get; set; }

    [NotMapped]
    public string PriceRange => Foods is null ? "-" : $"{Foods.Min(x => x.LowerPriceRange)}€ - {Foods.Max(x => x.UpperPriceRange)}€";
}
