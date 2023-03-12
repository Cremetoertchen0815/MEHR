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
}
