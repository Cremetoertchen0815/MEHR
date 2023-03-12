namespace MEHR.Models;

public class Food
{
    public int Id { get; set; }
    public int Target { get; set; }
    public string Name { get; set; }
    public decimal LowerPriceRange { get; set; }
    public decimal UpperPriceRange { get; set; }
    public uint Tag { get; set; }
}
