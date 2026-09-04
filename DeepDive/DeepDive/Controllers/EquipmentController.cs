using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
