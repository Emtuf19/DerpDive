using DeepDive.Services;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ICompleteWeatherService _completeWeatherService;
        public WeatherController(ICompleteWeatherService completeWeatherService)
        {
            _completeWeatherService = completeWeatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            var location = await _completeWeatherService.GetLocationAsync(city);

            var weather = await _completeWeatherService.GetWeatherAsync(location.Latitude, location.Longitude);
            var marineWeather = await _completeWeatherService.GetMarineWeatherAsync(location.Latitude, location.Longitude);

            var vm = new WeatherVM
            {
                City = city,
                Geocoding = location,
                Weather = weather,
                MarineWeather = marineWeather,
            };

            return View(vm);
        }
    }
}
