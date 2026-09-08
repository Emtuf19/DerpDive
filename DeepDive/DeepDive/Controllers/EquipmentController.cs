using DeepDive.Models;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DeepDive.Data;
using DeepDive.Persistance;

namespace DeepDive.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IMask_SnorkelRepository Mask_SnorkelRepository;
        private readonly IBCDRepository BCDRepository;
        private readonly ITankRepository TankRepository;
        private readonly IDivingSuitsRepository DivingSuitsRepository;
        private readonly IRegulatorSetRepository RegulatorSetRepository;
        private readonly IFinnsRepository FinnsRepository;

        public EquipmentController(IMask_SnorkelRepository mask_SnorkelRepository, IBCDRepository bCDRepository, ITankRepository tankRepository, IDivingSuitsRepository divingSuitsRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository)
        {
            Mask_SnorkelRepository = mask_SnorkelRepository;
            BCDRepository = bCDRepository;
            TankRepository = tankRepository;
            DivingSuitsRepository = divingSuitsRepository;
            RegulatorSetRepository = regulatorSetRepository;
            FinnsRepository = finnsRepository;
        }
        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Mask_Snorkel()
        {
            ViewBag.Action = "Mask_Snorkel";

            var mask_snorkels = Mask_SnorkelRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                mask_Snorkels = mask_snorkels
            };

            return View(vm);
        }

        public IActionResult Tank()
        {
            ViewBag.Action = "Tank";

            var tanks = TankRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                tanks = tanks
            };

            return View(vm);
        }

        public IActionResult DivingSuits()
        {
            ViewBag.Action = "DivingSuits";

            var divingSuits = DivingSuitsRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                divingSuits = divingSuits
            };

            return View(vm);
        }

        public IActionResult RegulatorSet()
        {
            ViewBag.Action = "RegulatorSet";

            var regulatorSets = RegulatorSetRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                regulatorSets = regulatorSets
            };

            return View(vm);
        }
        
        public IActionResult BCD()
        {
            ViewBag.Action = "BCD";

            var BCDs = BCDRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                bcds = BCDs
            };

            return View(vm);
        }

        public IActionResult Finns()
        {
            ViewBag.Action = "Finns";

            var finns = FinnsRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                finns = finns
            };

            return View(vm);
        }
    }
}
