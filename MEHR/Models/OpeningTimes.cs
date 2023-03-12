namespace MEHR.Models;

[Serializable]
public struct OpeningTimes
{
    public uint SeasonStart { get; set; }
    public uint SeasonEnd { get; set; }

    public TimeRange Monday { get; set; }
    public TimeRange Tuesday { get; set; }
    public TimeRange Wednesday { get; set; }
    public TimeRange Thursday { get; set; }
    public TimeRange Friday { get; set; }
}
