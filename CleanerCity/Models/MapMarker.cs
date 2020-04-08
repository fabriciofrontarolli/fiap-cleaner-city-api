namespace CleanerCity.Models
{
    public class MapMarker
    {
        public MapMarker() { }
        public MapMarker(string title, string latitude, string longitude)
        {
            Title = title;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
