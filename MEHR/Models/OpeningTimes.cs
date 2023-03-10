using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEHR.Models;

[ComplexType]
public class OpeningTimes
{
    public int Id { get; set; }
    public int Target { get; set; }

    public uint SeasonStart { get; set; }
    public uint SeasonEnd { get; set; }

    public ulong Monday { get; set; }
    public ulong Tuesday { get; set; }
    public ulong Wednesday { get; set; }
    public ulong Thursday { get; set; }
    public ulong Friday { get; set; }
}
