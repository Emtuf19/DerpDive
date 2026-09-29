using DeepDive.Models;

namespace DeepDive.ViewModels
{
    public class WeatherVM
    {
        public string City { get; set; }
        public Geocoding Geocoding { get; set; }
        public Weather Weather { get; set; }
        public MarineWeather MarineWeather { get; set; }
    }
}
