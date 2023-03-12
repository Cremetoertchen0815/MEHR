using Newtonsoft.Json;

namespace MEHR.Models;

[Serializable]
public struct TimeRange
{
    public TimeOnly OpeningTime {  get; set; }
    public TimeOnly LunchBreakStart { get; set; }
    public TimeOnly LunchBreakEnd { get; set; }
    public TimeOnly ClosingTime { get; set; }

    public TimeRange(TimeOnly OpeningTime, TimeOnly LunchBreakStart, TimeOnly LunchBreakEnd, TimeOnly ClosingTime)
    {
        this.OpeningTime = OpeningTime;
        this.LunchBreakStart = LunchBreakStart;
        this.LunchBreakEnd = LunchBreakEnd;
        this.ClosingTime = ClosingTime;
    }
    public TimeRange(TimeOnly OpeningTime, TimeOnly ClosingTime)
    {
        this.OpeningTime = OpeningTime;
        this.LunchBreakStart = TimeOnly.MinValue;
        this.LunchBreakEnd = TimeOnly.MinValue;
        this.ClosingTime = ClosingTime;
    }

    [JsonIgnore]
    public bool HasLunchBreak => (LunchBreakEnd - LunchBreakStart).TotalSeconds > 0;
}
