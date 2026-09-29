using System.Text.Json.Serialization;

namespace DeepDive.Models
{
    public class MarineWeather
    {
        [JsonPropertyName("current")]
        public CurrentMarineWeather Current { get; set; }
    }

    public class CurrentMarineWeather
    {
        [JsonPropertyName("wave_height")]
        public double? WaveHeight { get; set; }

        [JsonPropertyName("sea_surface_temperature")]
        public double? SeaSurfaceTemperature { get; set; }
    }
}