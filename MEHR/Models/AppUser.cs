using System.ComponentModel.DataAnnotations;

namespace MEHR.Models;

public class AppUser
{
    [Key]
    public int Id { get; set; }
    public ulong CookieHash { get; set; }
    public ICollection<LocationRating>? Ratings { get; set; }
    public ICollection<HistoryItem>? History { get; set; }
}
