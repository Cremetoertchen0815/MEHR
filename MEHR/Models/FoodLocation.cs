using Geolocation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEHR.Models;

public class FoodLocation
{
    public int Id { get; set; }
    public double LocationLatitude { get; set; }
    public double LocationLongitude { get; set; }
    public int Icon { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public bool HasDelivery { get; set; }

    [ForeignKey("Target")]
    public List<Food> Foods { get; set; } = new();

    [ForeignKey("Target")]
    public List<LocationRating> Ratings { get; set; } = new();

    public string OpeningTimesSerial
    {
        get => JsonConvert.SerializeObject(OpeningTimes);
        set => OpeningTimes = JsonConvert.DeserializeObject<OpeningTimes>(value);
    }

    [NotMapped]
    public OpeningTimes OpeningTimes { get; set; }
}
