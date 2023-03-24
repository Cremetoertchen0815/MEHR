namespace MEHR.Models;

public record struct RatingInfo
(
    string Text,
    float RatingNr
)
{
    public static RatingInfo FromRating(LocationRating rating) => new RatingInfo(rating.Text ?? "-", rating.Rating);
}
