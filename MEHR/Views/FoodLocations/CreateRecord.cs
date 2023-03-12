using MEHR.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MEHR.Views.FoodLocations;

public record DataSyncRecord
    (
    string LocationLatitude,
    string LocationLongitude,
    string Icon,
    string Name,
    string Description,
    string PhoneNumber,
    string HasDelivery,
    string SeasonStart,
    string SeasonEnd,
    string TimeOpenMonday,
    string TimeCloseMonday,
    string TimeOpenTuesday,
    string TimeCloseTuesday,
    string TimeOpenWednesday,
    string TimeCloseWednesday,
    string TimeOpenThursday,
    string TimeCloseThursday,
    string TimeOpenFriday,
    string TimeCloseFriday
    )
{
    public FoodLocation SyncData(FoodLocation foodLocation)
    {
        foodLocation.Description = Description;
        foodLocation.Name = Name;
        foodLocation.PhoneNumber = PhoneNumber;
        foodLocation.LocationLatitude = double.Parse(LocationLatitude);
        foodLocation.LocationLongitude = double.Parse(LocationLongitude);
        foodLocation.HasDelivery = HasDelivery == "on";
        foodLocation.Icon = int.Parse(Icon);
        foodLocation.OpeningTimes = new OpeningTimes()
        {
            SeasonStart = (DateOnly.Parse(SeasonStart).Day, DateOnly.Parse(SeasonStart).Month),
            SeasonEnd = (DateOnly.Parse(SeasonEnd).Day, DateOnly.Parse(SeasonEnd).Month),
            Monday = (TimeOnly.Parse(TimeOpenMonday), TimeOnly.Parse(TimeCloseMonday)),
            Tuesday = (TimeOnly.Parse(TimeOpenTuesday), TimeOnly.Parse(TimeCloseTuesday)),
            Wednesday = (TimeOnly.Parse(TimeOpenWednesday), TimeOnly.Parse(TimeCloseWednesday)),
            Thursday = (TimeOnly.Parse(TimeOpenThursday), TimeOnly.Parse(TimeCloseThursday)),
            Friday = (TimeOnly.Parse(TimeOpenFriday), TimeOnly.Parse(TimeCloseFriday)),
        };
        return foodLocation;
    }
}