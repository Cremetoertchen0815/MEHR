using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEHR.Models;

public class Food
{
    [Key]
    public int Id { get; set; }
    public int Target { get; set; }
    public string Name { get; set; }
    public decimal LowerPriceRange { get; set; }
    public decimal UpperPriceRange { get; set; }
    public uint Tag { get; set; }
}
