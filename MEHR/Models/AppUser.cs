namespace MEHR.Models;

public class AppUser
{
    public uint Id { get; set; }
    public ulong CookieHash { get; set; }
    public List<uint> RecentLocations { get; set; } = new();
}
