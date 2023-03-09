using Geolocation;

namespace MEHR.Models;

public class FoodLocation
{
    public uint Id { get; set; }
    public Coordinate Location { get; set; }
    public uint Icon { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public bool HasDelivery { get; set; }
    public List<uint> Foods { get; set; } = new();
    public OpeningTimes OpeningTimes { get; set; } = new();
}
