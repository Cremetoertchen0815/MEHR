namespace MEHR.Models;

public class HistoryItem
{
    public int Id { get; set; }
    public AppUser? Owner { get; set; }
    public FoodLocation? Location { get; set; }
    public long CreationDate { get; set; }
}
