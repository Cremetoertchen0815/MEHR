using Geolocation;
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
    public ICollection<Food> Foods { get; set; }

    [ForeignKey("Target")]
    public ICollection<LocationRating> Ratings { get; set; }

    [ForeignKey("Target")]
    public OpeningTimes OpeningTimes { get; set; }

    //public OpeningTimes OpeningTimes { get; set; } = new();
}
