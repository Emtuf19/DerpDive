using DeepDive.Models;
using DeepDive.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeepDive.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPackageRepository _packageRepository;

        public HomeController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public IActionResult Index()
        {
            var packages = _packageRepository.GetAll();
            return View(packages);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult PracticalInformation()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
