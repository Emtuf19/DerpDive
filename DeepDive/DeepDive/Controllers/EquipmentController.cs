using DeepDive.Models;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DeepDive.Data;
using DeepDive.Persistance;

namespace DeepDive.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IMask_SnorkelRepository _mask_SnorkelRepository;
        private readonly IBCDRepository _bcdRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IDivingSuitsRepository _divingSuitsRepository;
        private readonly IRegulatorSetRepository _regulatorSetRepository;
        private readonly IFinnsRepository _finnsRepository;

        public EquipmentController(IMask_SnorkelRepository mask_SnorkelRepository, IBCDRepository bCDRepository, ITankRepository tankRepository, IDivingSuitsRepository divingSuitsRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository)
        {
            _mask_SnorkelRepository = mask_SnorkelRepository;
            _bcdRepository = bCDRepository;
            _tankRepository = tankRepository;
            _divingSuitsRepository = divingSuitsRepository;
            _regulatorSetRepository = regulatorSetRepository;
            _finnsRepository = finnsRepository;
        }
        public IActionResult Category()
        {
            return View();
        }

        public async Task<IActionResult> Mask_Snorkel()
        {
            ViewBag.Action = "Mask_Snorkel";

            var mask_snorkels = await _mask_SnorkelRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                mask_Snorkels = mask_snorkels
            };

            return View(vm);
        }

        public async Task<IActionResult> Tank()
        {
            ViewBag.Action = "Tank";

            var tanks = await _tankRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                tanks = tanks
            };

            return View(vm);
        }

        public async Task<IActionResult> DivingSuits( int? thickness)
        {
            ViewBag.Action = "DivingSuits";

            var divingSuits = await _divingSuitsRepository.GetAll();

            if (thickness != null)
            {
                divingSuits = divingSuits
                    .Where(s => s.Thickness == thickness)
                    .ToList();
            }


            var vm = new AllEquipmentViewData
            {
                divingSuits = divingSuits
            };

            return View(vm);
        }

        public async Task<IActionResult> RegulatorSet()
        {
            ViewBag.Action = "RegulatorSet";

            var regulatorSets = await _regulatorSetRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                regulatorSets = regulatorSets
            };

            return View(vm);
        }
        
        public async Task<IActionResult> BCD()
        {
            ViewBag.Action = "BCD";

            var BCDs = await _bcdRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                bcds = BCDs
            };

            return View(vm);
        }

        public async Task<IActionResult> Finns()
        {
            ViewBag.Action = "Finns";

            var finns = await _finnsRepository.GetAll();

            var vm = new AllEquipmentViewData
            {
                finns = finns
            };

            return View(vm);
        }
    }
}
