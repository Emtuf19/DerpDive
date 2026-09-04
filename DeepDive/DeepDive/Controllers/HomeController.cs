using DeepDive.Models;
using DeepDive.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeepDive.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var packages = PackageRepository.GetAll();
            return View(packages);
        }

        public IActionResult Privacy()
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
