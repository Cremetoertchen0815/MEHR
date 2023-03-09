namespace MEHR.Models;

public class LocationRating
{
    public uint Id { get; set; }
    public uint Target { get; set; }
    public uint Author { get; set; }
    public float Rating { get; set; }
    public string Text { get; set; }
}
