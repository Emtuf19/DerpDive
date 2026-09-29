using System.Text.Json.Serialization;

namespace DeepDive.Models
{
    public class Weather
    {
        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }

    public class Current
    {
        [JsonPropertyName("temperature_2m")]
        public double? Temperature { get; set; }

        [JsonPropertyName("rain")]
        public double? Rain { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double? WindSpeed { get; set; }

        [JsonPropertyName("weather_code")]
        public int? WeatherCode { get; set; }
    }
}