using DeepDive.Extensions;
using DeepDive.Models;
using DeepDive.Persistance;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DeepDive.Enums;

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
            var bcd = BCDRepository.GetById(id);

            if (bcd == null)
            {
                return NotFound();
            }

            var vm = new SpecificBCD
            {
                BCDId = bcd.BCDId,
                Brand = bcd.Brand,
                Model = bcd.Model,
                Price = bcd.Price,
                DateFrom = bcd.DateFrom,
                DateTo = bcd.DateTo,
                AvailableSizes = bcd.Size
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificBCD(SpecificBCD vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            bool alreadyInCart = cart.Items.Any(item =>
                item.EquipmentType == EquipmentType.BCD &&
                item.EquipmentId == vm.BCDId &&
                vm.SelectedSize == item.SelectedSize &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (alreadyInCart)
            {
                ModelState.AddModelError(string.Empty, "Denne BCD er allerede udlejet i dette tidsrum");
                return View(vm);
            }


            var cartItem = new CartItem
            {
                EquipmentType = EquipmentType.BCD,
                EquipmentId = vm.BCDId,
                SelectedSize = vm.SelectedSize,
                DateFrom = vm.DateFrom,
                DateTo = vm.DateTo,
                Price = vm.Price
            };

            cart.Items.Add(cartItem);

            HttpContext.Session.SetObject("Cart", cart);

            //Redirect fixer at man ikke kan vælge størrelse osv
            return RedirectToAction("SpecificBCD", new { id = vm.BCDId });
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
                DateFrom = sDivingSuit.DateFrom,
                DateTo = sDivingSuit.DateTo,
                AvailableGenders = sDivingSuit.Gender,
                AvailableSizes = sDivingSuit.Size
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificDivingSuits(SpecificDivingSuitVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            bool alreadyInCart = cart.Items.Any(item =>
                item.EquipmentType == EquipmentType.DivingSuits &&
                item.EquipmentId == vm.DivingSuitsId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (alreadyInCart)
            {
                ModelState.AddModelError(string.Empty, "Denne dragt er allerede udlejet i dette tidsrum");
                return View(vm);
            }

            var cartItem = new CartItem
            {
                EquipmentType = EquipmentType.DivingSuits,
                EquipmentId = vm.DivingSuitsId,
                SelectedSize = vm.SelectedSize,
                SelectedGender = vm.SelectedGender,
                DateFrom = vm.DateFrom,
                DateTo = vm.DateTo,
                Price = vm.Price
            };

            cart.Items.Add(cartItem);

            HttpContext.Session.SetObject("Cart", cart);

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
                AvailableSizes = sFinns.Size,
                DateFrom = sFinns.DateFrom,
                DateTo = sFinns.DateTo,
                Price = sFinns.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificFinns(SpecificFinns vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            bool alreadyInCart = cart.Items.Any(item =>
                item.EquipmentType == EquipmentType.Finns &&
                item.EquipmentId == vm.FinnsId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (alreadyInCart)
            {
                ModelState.AddModelError(string.Empty, "Disse finner er allerede udlejet i dette tidsrum");
                return View(vm);
            }

            var cartItem = new CartItem
            {
                EquipmentType = EquipmentType.Finns,
                EquipmentId = vm.FinnsId,
                SelectedSize = vm.SelectedSize,
                DateFrom = vm.DateFrom,
                DateTo = vm.DateTo,
                Price = vm.Price
            };

            cart.Items.Add(cartItem);

            HttpContext.Session.SetObject("Cart", cart);

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
                DateFrom = sMask_Snorkel.DateFrom,
                DateTo = sMask_Snorkel.DateTo,
                Price = sMask_Snorkel.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificMask_Snorkel(SpecificMask_Snorkel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            bool alreadyInCart = cart.Items.Any(item =>
                item.EquipmentType == EquipmentType.Mask_Snorkel &&
                item.EquipmentId == vm.Mask_SnorkelId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (alreadyInCart)
            {
                ModelState.AddModelError(string.Empty, "Denne Maske/Snorkel er allerede udlejet i dette tidsrum");
                return View(vm);
            }

            var cartItem = new CartItem
            {
                EquipmentType = EquipmentType.Mask_Snorkel,
                EquipmentId = vm.Mask_SnorkelId,
                DateFrom = vm.DateFrom,
                DateTo = vm.DateTo,
                Price = vm.Price
            };

            cart.Items.Add(cartItem);

            HttpContext.Session.SetObject("Cart", cart);

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
                DateFrom = sRegulatorSet.DateFrom,
                DateTo = sRegulatorSet.DateTo,
                Price = sRegulatorSet.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificRegulatorSet(SpecificRegulatorSet vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            bool alreadyInCart = cart.Items.Any(item =>
                item.EquipmentType == EquipmentType.RegulatorSet &&
                item.EquipmentId == vm.RegulatorSetId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (alreadyInCart)
            {
                ModelState.AddModelError(string.Empty, "Dette RegulatorSet er allerede udlejet i dette tidsrum");
                return View(vm);
            }

            var cartItem = new CartItem
            {
                EquipmentType = EquipmentType.RegulatorSet,
                EquipmentId = vm.RegulatorSetId,
                DateFrom = vm.DateFrom,
                DateTo = vm.DateTo,
                Price = vm.Price
            };

            cart.Items.Add(cartItem);

            HttpContext.Session.SetObject("Cart", cart);

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
                DateFrom = sTank.DateFrom,
                DateTo = sTank.DateTo,
                Price = sTank.Price
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificTank(SpecificTank vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            bool alreadyInCart = cart.Items.Any(item =>
                item.EquipmentType == EquipmentType.Tank &&
                item.EquipmentId == vm.TankId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (alreadyInCart)
            {
                ModelState.AddModelError(string.Empty, "Denne Tank er allerede udlejet i dette tidsrum");
                return View(vm);
            }

            var cartItem = new CartItem
            {
                EquipmentType = EquipmentType.Tank,
                EquipmentId = vm.TankId,
                DateFrom = vm.DateFrom,
                DateTo = vm.DateTo,
                Price = vm.Price
            };

            cart.Items.Add(cartItem);

            HttpContext.Session.SetObject("Cart", cart);

            return View(vm);
        }
    }
}