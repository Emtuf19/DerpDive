using DeepDive.Models;
using DeepDive.Persistance;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    public class SpecificEquipmentController : Controller
    {
        private readonly IMask_SnorkelRepository Mask_SnorkelRepository;
        private readonly IBCDRepository BCDRepository;
        private readonly ITankRepository TankRepository;
        private readonly IDivingSuitsRepository DivingSuitsRepository;
        private readonly IRegulatorSetRepository RegulatorSetRepository;
        private readonly IFinnsRepository FinnsRepository;

        public SpecificEquipmentController(IMask_SnorkelRepository mask_SnorkelRepository, IBCDRepository bCDRepository, ITankRepository tankRepository, IDivingSuitsRepository divingSuitsRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository)
        {
            Mask_SnorkelRepository = mask_SnorkelRepository;
            BCDRepository = bCDRepository;
            TankRepository = tankRepository;
            DivingSuitsRepository = divingSuitsRepository;
            RegulatorSetRepository = regulatorSetRepository;
            FinnsRepository = finnsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SpecificBCD(int id)
        {
            var sBCD = BCDRepository.GetById(id);
            if (sBCD == null)
            {
                return NotFound();
            }

            var vm = new SpecificBCD
            {
                BCDId = sBCD.BCDId,
                Brand = sBCD.Brand,
                Model = sBCD.Model,
                Size = sBCD.Size,
                Price = sBCD.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificBCD(SpecificBCD vm)
        {
            var id = vm.BCDId;
            var size = vm.Size;

            return View(vm);
        }

        public IActionResult SpecificDivingSuits(int id)
        {
            var sDivingSuit = DivingSuitsRepository.GetById(id);
            if (sDivingSuit == null)
            {
                return NotFound();
            }

            var vm = new SpecificDivingSuitVM
            {
                DivingSuitsId = sDivingSuit.DivingSuitsId,
                Brand = sDivingSuit.Brand,
                Model = sDivingSuit.Model,
                Type = sDivingSuit.Type,
                Thickness = sDivingSuit.Thickness,
                Price = sDivingSuit.Price,
                Gender = sDivingSuit.Gender,
                Size = sDivingSuit.Size
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificDivingSuits(SpecificDivingSuitVM vm)
        {
            // Her har du brugerens valg

            var id = vm.DivingSuitsId; //ikke sikker på ID skal med??
            var gender = vm.Gender;
            var size = vm.Size;

            // Gør noget med valget...

            return View(vm);
        }

        public IActionResult SpecificFinns(int id)
        {
            var sFinns = FinnsRepository.GetById(id);
            if (sFinns == null)
            {
                return NotFound();
            }

            var vm = new SpecificFinns
            {
                FinnsId = sFinns.FinnsId,
                Brand = sFinns.Brand,
                Model = sFinns.Model,
                Size = sFinns.Size,
                Price = sFinns.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificFinns(SpecificFinns vm)
        {
            var id = vm.FinnsId;
            var size = vm.Size;

            return View(vm);
        }

        public IActionResult SpecificMask_Snorkel(int id)
        {
            var sMask_Snorkel = Mask_SnorkelRepository.GetById(id);
            if (sMask_Snorkel == null)
            {
                return NotFound();
            }

            var vm = new SpecificMask_Snorkel
            {
                Mask_SnorkelId = sMask_Snorkel.Mask_SnorkelId,
                Brand = sMask_Snorkel.Brand,
                Model = sMask_Snorkel.Model,
                Price = sMask_Snorkel.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificMask_Snorkel(SpecificMask_Snorkel vm)
        {
            var id = vm.Mask_SnorkelId;

            return View(vm);
        }

        public IActionResult SpecificRegulatorSet(int id)
        {
            var sRegulatorSet = RegulatorSetRepository.GetById(id);
            if (sRegulatorSet == null)
            {
                return NotFound();
            }

            var vm = new SpecificRegulatorSet
            {
                RegulatorSetId = sRegulatorSet.RegulatorSetId,
                Brand = sRegulatorSet.Brand,
                FirstStep = sRegulatorSet.FirstStep,
                SecondStep = sRegulatorSet.SecondStep,
                Octopus = sRegulatorSet.Octopus,
                Price = sRegulatorSet.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificRegulatorSet(SpecificRegulatorSet vm)
        {
            var id = vm.RegulatorSetId;
            var firstStep = vm.FirstStep;
            var secondStep = vm.SecondStep;
            var octopus = vm.Octopus;

            return View(vm);
        }

        public IActionResult SpecificTank(int id)
        {
            var sTank = TankRepository.GetById(id);
            if (sTank == null)
            {
                return NotFound();
            }

            var vm = new SpecificTank
            {
                TankId = sTank.TankId,
                Brand = sTank.Brand,
                Volumen = sTank.Volumen,
                Price = sTank.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificTank(SpecificTank vm)
        {
            var id = vm.TankId;
            var volumen = vm.Volumen;

            return View(vm);
        }
    }
}