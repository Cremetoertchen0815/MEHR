using System.ComponentModel.DataAnnotations;

namespace MEHR.Models;

public class LocationRating
{
    public int Id { get; set; }
    public FoodLocation? Location { get; set; }
    public AppUser? Author { get; set; }
    public float Rating { get; set; }
    public string? Text { get; set; }
}
