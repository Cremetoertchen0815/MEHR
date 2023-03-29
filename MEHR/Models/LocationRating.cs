namespace MEHR.Models;

public class LocationRating
{
    public int Id { get; set; }
    public FoodLocation? Location { get; set; }
    public AppUser? Author { get; set; }
    public int Rating { get; set; }
    public string? Text { get; set; }
}
