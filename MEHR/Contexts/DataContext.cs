using MEHR.Models;
using Microsoft.EntityFrameworkCore;

namespace MEHR.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodLocation>().HasMany(x => x.Foods).WithOne(x => x.Location).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<FoodLocation>().HasMany(x => x.Ratings).WithOne(x => x.Location).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<AppUser>().HasMany(x => x.Ratings).WithOne(x => x.Author).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<AppUser>().HasMany(x => x.History).WithOne(x => x.Owner).OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<FoodLocation> FoodLocations { get; set; }
    public DbSet<LocationRating> Ratings { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodTag> FoodTags { get; set; }
    public DbSet<HistoryItem> HistoryItems { get; set; }
}
