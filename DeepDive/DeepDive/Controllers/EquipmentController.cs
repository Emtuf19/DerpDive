using DeepDive.Models;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Mask_Snorkel()
        {
            ViewBag.Action = "Mask_Snorkel";

            var mask_snorkels = Persistance.EquipmentRepository.GetAllMask_Snorkels();

            var vm = new AllEquipmentViewData
            {
                mask_Snorkels = mask_snorkels
            };

            return View(vm);
        }

        public IActionResult Tank()
        {
            ViewBag.Action = "Tank";

            var tanks = Persistance.EquipmentRepository.GetAllTanks();

            var vm = new AllEquipmentViewData
            {
                tanks = tanks
            };

            return View(vm);
        }

        public IActionResult DivingSuits()
        {
            ViewBag.Action = "DivingSuits";

            var divingSuits = Persistance.EquipmentRepository.GetAllDivingSuits();

            var vm = new AllEquipmentViewData
            {
                divingSuits = divingSuits
            };

            return View(vm);
        }

        public IActionResult RegulatorSet()
        {
            ViewBag.Action = "RegulatorSet";

            var regulatorSets = Persistance.EquipmentRepository.GetAllRegulatorSets();

            var vm = new AllEquipmentViewData
            {
                regulatorSets = regulatorSets
            };

            return View(vm);
        }
        
        public IActionResult BCD()
        {
            ViewBag.Action = "BCD";

            var BCDs = Persistance.EquipmentRepository.GetAllBCDs();

            var vm = new AllEquipmentViewData
            {
                bcds = BCDs
            };

            return View(vm);
        }

        public IActionResult Finns()
        {
            ViewBag.Action = "Finns";

            var finns = Persistance.EquipmentRepository.GetAllFinns();

            var vm = new AllEquipmentViewData
            {
                finns = finns
            };

            return View(vm);
        }

        public IActionResult _SpecificEquipment()
        {
            return View();
        }

    }
}
