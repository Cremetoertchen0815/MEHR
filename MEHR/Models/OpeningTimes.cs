namespace MEHR.Models;

public class OpeningTimes
{
    public List<DateOnly> Holidays { get; set; } = new();
    public DateOnly SeasonStart { get; set; }
    public DateOnly SeasonEnd { get; set; }
    
    public TimeRange Monday { get; set; }
    public TimeRange Tuesday { get; set; }
    public TimeRange Wednesday { get; set; }
    public TimeRange Thursday { get; set; }
    public TimeRange Friday { get; set; }
}
