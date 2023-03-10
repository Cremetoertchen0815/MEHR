using MEHR.Models;
using Microsoft.EntityFrameworkCore;

namespace MEHR.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<FoodLocation> FoodLocations { get; set; }
    public DbSet<LocationRating> Ratings { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodTag> FoodTags { get; set; }
}
