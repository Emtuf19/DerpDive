using DeepDive.Models;

namespace DeepDive.Services
{
    public interface ICompleteWeatherService
    {
        Task<Geocoding> GetLocationAsync(string city);
        Task<Weather> GetWeatherAsync(double latitude, double longitude);
        Task<MarineWeather>GetMarineWeatherAsync(double latitude, double longitude);
    }
}
