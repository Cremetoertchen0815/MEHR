using Microsoft.EntityFrameworkCore;

namespace MEHR.Contexts;

public class TestContext : DbContext
{
    public TestContext(DbContextOptions<TestContext> options) : base(options)
    {
        
    }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}
