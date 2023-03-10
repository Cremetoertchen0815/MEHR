using System.ComponentModel.DataAnnotations;

namespace MEHR.Models;

public class LocationRating
{
    [Key]
    public int Id { get; set; }
    public int Target { get; set; }
    public int Author { get; set; }
    public float Rating { get; set; }
    public string Text { get; set; }
}
