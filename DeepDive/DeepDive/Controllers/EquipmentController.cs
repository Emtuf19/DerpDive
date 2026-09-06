using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<string> { "BCD", "Dykkerdragter", "Finner", "Masker", "RegulatorSæt", "Tank" };
            return View(categories);
            
        }
        public IActionResult Category(string id)
        {
            var items = new List<dynamic>
        {
            new { Id = 1, Name = id + " Model A", Description = "Test beskrivelse", Price = 999, ImageUrl = "/IMGs/placeholder.jpg" },
            new { Id = 2, Name = id + " Model B", Description = "Test beskrivelse", Price = 1499, ImageUrl = "/IMGs/placeholder.jpg" }
        };

            ViewBag.Category = id;
            return View(items);
        }

        public IActionResult Details(string category, int id)
        {
            dynamic item = new
            {
                Id = id,
                Name = category + " Model " + id,
                Description = "Test beskrivelse af produktet",
                Price = 1200m,
                ImageUrl = "/IMGs/placeholder.jpg"
            };

            ViewBag.Category = category;
            return View(item);
        }
    }

}

