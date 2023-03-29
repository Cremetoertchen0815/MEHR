namespace MEHR.Models;

public record struct RatingInfo
(
    string Text,
    int RatingNr
)
{
    public static RatingInfo FromRating(LocationRating rating) => new RatingInfo(rating.Text ?? "-", rating.Rating);
}
