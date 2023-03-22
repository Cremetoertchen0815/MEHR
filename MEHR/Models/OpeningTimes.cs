using System.Text;

namespace MEHR.Models;

[Serializable]
public struct OpeningTimes
{
    public (int Day, int Month) SeasonStart { get; set; }
    public (int Day, int Month) SeasonEnd { get; set; }

    public (TimeOnly Start, TimeOnly End) Monday { get; set; }
    public (TimeOnly Start, TimeOnly End) Tuesday { get; set; }
    public (TimeOnly Start, TimeOnly End) Wednesday { get; set; }
    public (TimeOnly Start, TimeOnly End) Thursday { get; set; }
    public (TimeOnly Start, TimeOnly End) Friday { get; set; }

    public string ToHtml()
    {
        StringBuilder sb = new StringBuilder();
        if ((Monday.End - Monday.Start).Ticks > 0) sb.AppendLine($"Monday: {Monday.Start}-{Monday.End}<br>");
        if ((Tuesday.End - Tuesday.Start).Ticks > 0) sb.AppendLine($"Tuesday: {Tuesday.Start}-{Tuesday.End}<br>");
        if ((Wednesday.End - Wednesday.Start).Ticks > 0) sb.AppendLine($"Wednesday: {Wednesday.Start}-{Wednesday.End}<br>");
        if ((Thursday.End - Thursday.Start).Ticks > 0) sb.AppendLine($"Thursday: {Thursday.Start}-{Thursday.End} <br>");
        if ((Friday.End - Friday.Start).Ticks > 0) sb.AppendLine($"Friday: {Friday.Start}-{Friday.End}<br>");
        if (SeasonStart != SeasonEnd) sb.AppendLine($"<br>Season: {SeasonStart.Day}.{SeasonStart.Month} - {SeasonEnd.Day}.{SeasonEnd.Month}");
        return sb.ToString();
    }

    public bool IsOpenAt(DateTime date) => date.DayOfWeek switch
    {
        DayOfWeek.Monday => Monday.Start.ToTimeSpan() >= date.TimeOfDay && Monday.End.ToTimeSpan() < date.TimeOfDay,
        DayOfWeek.Tuesday => Monday.Start.ToTimeSpan() >= date.TimeOfDay && Monday.End.ToTimeSpan() < date.TimeOfDay,
        DayOfWeek.Wednesday => Monday.Start.ToTimeSpan() >= date.TimeOfDay && Monday.End.ToTimeSpan() < date.TimeOfDay,
        DayOfWeek.Thursday => Monday.Start.ToTimeSpan() >= date.TimeOfDay && Monday.End.ToTimeSpan() < date.TimeOfDay,
        DayOfWeek.Friday => Monday.Start.ToTimeSpan() >= date.TimeOfDay && Monday.End.ToTimeSpan() < date.TimeOfDay,
        _ => false
    }; //TODO: Add Season check
}
