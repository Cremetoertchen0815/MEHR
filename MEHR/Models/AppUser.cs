using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEHR.Models;

public class AppUser
{
    [Key]
    public int Id { get; set; }
    public ulong CookieHash { get; set; }

    [ForeignKey("Author")]
    public ICollection<LocationRating> Ratings { get; set; }
    //public ICollection<uint> RecentLocations { get; set; }
}
