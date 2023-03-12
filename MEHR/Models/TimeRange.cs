using Newtonsoft.Json;

namespace MEHR.Models;

[Serializable]
public struct TimeRange
{
    public TimeOnly OpeningTime {  get; set; }
    public TimeOnly ClosingTime { get; set; }

    public TimeRange(TimeOnly OpeningTime, TimeOnly LunchBreakStart, TimeOnly LunchBreakEnd, TimeOnly ClosingTime)
    {
        this.OpeningTime = OpeningTime;
        this.ClosingTime = ClosingTime;
    }
    public TimeRange(TimeOnly OpeningTime, TimeOnly ClosingTime)
    {
        this.OpeningTime = OpeningTime;
        this.ClosingTime = ClosingTime;
    }
}
