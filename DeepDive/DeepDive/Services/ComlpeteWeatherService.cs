using DeepDive.Models;
using System.Globalization;

namespace DeepDive.Services
{
    public class ComlpeteWeatherService : ICompleteWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ComlpeteWeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Geocoding> GetLocationAsync(string city)
        {
            using var httpClient = _httpClientFactory.CreateClient("GeocodingClient");

            var response = await httpClient.GetAsync($"?city={city}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Geocoding API fejl: {response.StatusCode} - {content}");
            }

            var result = await response.Content.ReadFromJsonAsync<List<Geocoding>>();

            return result.First();
        }

        public async Task<MarineWeather> GetMarineWeatherAsync(double latitude, double longitude)
        {
            using var httpClient = _httpClientFactory.CreateClient("MarineClient");

            var url =
                $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                "&current=wave_height,sea_surface_temperature";

            var response = await httpClient.GetFromJsonAsync<MarineWeather>(url);

            return response;
        }

        public async Task<Weather> GetWeatherAsync(double latitude, double longitude)
        {
            using var httpClient = _httpClientFactory.CreateClient("WeatherClient");

            var url =
                $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                "&current=temperature_2m,rain,wind_speed_10m,weather_code";

            var response = await httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"Weather API fejl: {response.StatusCode} - {content}");
            }

            var weather = await response.Content.ReadFromJsonAsync<Weather>();

            return weather;
        }
    }
}
