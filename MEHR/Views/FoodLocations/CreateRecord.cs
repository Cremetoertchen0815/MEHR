namespace MEHR.Views.FoodLocations;

public record CreateRecord 
    (
    string LocationLatitude,
    string LocationLongitude,
    string Icon,
    string Name,
    string Description,
    string PhoneNumber,
    string HasDelivery
    )
{
}
