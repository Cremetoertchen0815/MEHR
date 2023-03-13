using System.ComponentModel.DataAnnotations.Schema;

namespace MEHR.Models;

public class Food
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal LowerPriceRange { get; set; }
    public decimal UpperPriceRange { get; set; }
    public FoodLocation? Location { get; set; }
    public FoodTag? Tag { get; set; }
}
