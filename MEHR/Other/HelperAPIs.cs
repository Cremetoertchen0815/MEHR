namespace MEHR;

public class HelperAPIs
{
    public static double GetLocationBetweenCoords(double latA, double longA, double latB, double longB) => new Coordinate(latA, longA).DistanceInKMFrom(new Coordinate(latB, longB));

    public record struct Coordinate(double Latitude, double Longitude)
    {
        public static double EARTH_RADIUS_KM = 6371;
        /// <summary>
        /// Calculates the approximate birds-flight distance between this coordinate and the coordinate in the parameter
        /// </summary>
        /// <param name="coordinate">The coordinate.</param>
        /// <param name="units">The units to measure in</param>
        /// <returns></returns>
        public double DistanceInKMFrom(Coordinate coordinate)
        {
            double dLat = Deg2Rad(coordinate.Latitude - Latitude);
            double dLon = Deg2Rad(coordinate.Longitude - Longitude);
            double a = Math.Sin(dLat / 2) *
                       Math.Sin(dLat / 2) +
                       Math.Cos(Deg2Rad(Latitude)) *
                       Math.Cos(Deg2Rad(coordinate.Latitude)) *
                       Math.Sin(dLon / 2) *
                       Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            return EARTH_RADIUS_KM * c;
        }
        private double Deg2Rad(double deg) => deg * Math.PI / 180.0;
    }
}
