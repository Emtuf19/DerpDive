using DeepDive.Data;
using DeepDive.Enums;
using DeepDive.Extensions;
using DeepDive.Models;
using DeepDive.Persistance;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly IPackageRepository PackageRepository;

        private readonly EquipmentContext _context;

        public SpecificEquipmentController(IMask_SnorkelRepository mask_SnorkelRepository, IBCDRepository bCDRepository, ITankRepository tankRepository, IDivingSuitsRepository divingSuitsRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository, EquipmentContext context, IPackageRepository packageRepository)
        {
            Mask_SnorkelRepository = mask_SnorkelRepository;
            BCDRepository = bCDRepository;
            TankRepository = tankRepository;
            DivingSuitsRepository = divingSuitsRepository;
            RegulatorSetRepository = regulatorSetRepository;
            FinnsRepository = finnsRepository;
            PackageRepository = packageRepository;

            _context = context;
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
                ImageData = bcd.ImageData,
                ImageMimeType = bcd.ImageMimeType,
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
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            int cartCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.BCD &&
                item.EquipmentId == vm.BCDId &&
                vm.SelectedSize == item.SelectedSize &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);


            int bookedCount = _context.BookingItems.Count(item =>
                item.EquipmentType == EquipmentType.BCD &&
                item.EquipmentId == vm.BCDId &&
                item.SelectedSize == vm.SelectedSize &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (cartCount + bookedCount >= 5)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Der er ikke flere BCD'er i denne størrelse tilgængelige i det valgte tidsrum.");
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

            cart.AddItem(cartItem);

            HttpContext.Session.SetObject("Cart", cart);
            TempData["ItemAdded"] = true;

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

            int cartCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.DivingSuits &&
                item.EquipmentId == vm.DivingSuitsId &&
                item.SelectedSize == vm.SelectedSize &&
                item.SelectedGender == vm.SelectedGender &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            int bookedCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.DivingSuits &&
                item.EquipmentId == vm.DivingSuitsId &&
                item.SelectedSize == vm.SelectedSize &&
                item.SelectedGender == vm.SelectedGender &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (cartCount + bookedCount >= 5)
            {
                ModelState.AddModelError(string.Empty, "Der er ikke flere dragter ledige i denne størrelse i dette tidsrum");
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

            cart.AddItem(cartItem);

            HttpContext.Session.SetObject("Cart", cart);
            TempData["ItemAdded"] = true;

            return RedirectToAction("SpecificDivingSuits", new { id = vm.DivingSuitsId });

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

            int cartCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.Finns &&
                item.EquipmentId == vm.FinnsId &&
                item.SelectedSize == vm.SelectedSize &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            int bookedCount = _context.BookingItems.Count(item =>
                item.EquipmentType == EquipmentType.Finns &&
                item.EquipmentId == vm.FinnsId &&
                item.SelectedSize == vm.SelectedSize &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (cartCount + bookedCount >= 5)
            {
                ModelState.AddModelError(string.Empty, "Der er ikke flere finner i denne størelse ledige i dette tidsrum");
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

            cart.AddItem(cartItem);

            HttpContext.Session.SetObject("Cart", cart);
            TempData["ItemAdded"] = true;

            return RedirectToAction("SpecificFinns", new { id = vm.FinnsId });
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

            int cartCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.Mask_Snorkel &&
                item.EquipmentId == vm.Mask_SnorkelId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            int bookedCount = _context.BookingItems.Count(item =>
                item.EquipmentType == EquipmentType.Mask_Snorkel &&
                item.EquipmentId == vm.Mask_SnorkelId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (cartCount + bookedCount >= 5)
            {
                ModelState.AddModelError(string.Empty, "Der er ikke flere masker/snorkler ledige i dette tidsrum");
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

            cart.AddItem(cartItem);

            HttpContext.Session.SetObject("Cart", cart);
            TempData["ItemAdded"] = true;

            return RedirectToAction("SpecificMask_Snorkel", new { id = vm.Mask_SnorkelId });
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

            int cartCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.RegulatorSet &&
                item.EquipmentId == vm.RegulatorSetId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            int bookedCount = _context.BookingItems.Count(item =>
                item.EquipmentType == EquipmentType.RegulatorSet &&
                item.EquipmentId == vm.RegulatorSetId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (cartCount + bookedCount >= 5)
            {
                ModelState.AddModelError(string.Empty, "Der er ikke flere af denne type regulatorset ledige i dette tidsrum");
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

            cart.AddItem(cartItem);

            HttpContext.Session.SetObject("Cart", cart);
            TempData["ItemAdded"] = true;

            return RedirectToAction("SpecificRegulatorSet", new { id = vm.RegulatorSetId });
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

            int cartCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.Tank &&
                item.EquipmentId == vm.TankId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            int bookedCount = _context.BookingItems.Count(item =>
                item.EquipmentType == EquipmentType.Tank &&
                item.EquipmentId == vm.TankId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (cartCount + bookedCount >= 5)
            {
                ModelState.AddModelError(string.Empty, "Der er ikke flere af denne type tank ledige i dette tidsrum");
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

            cart.AddItem(cartItem);

            HttpContext.Session.SetObject("Cart", cart);
            TempData["ItemAdded"] = true;
            return RedirectToAction("SpecificTank", new { id = vm.TankId });
        }
        public IActionResult SpecificPackage(int id)
        {
            var package = PackageRepository.GetById(id);
            if (package == null)
            {
                return NotFound();
            }

            var vm = new SpecificPackage
            {
                PackageId = package.PackageId,
                Title = package.Title,
                Price = package.Price,
                Content = package.PackageItems.Select(i => i.EquipmentType).ToList(),
                DateFrom = DateTime.Today,
                DateTo = DateTime.Today.AddDays(1)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult SpecificPackage(SpecificPackage vm)
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

            int cartCount = cart.Items.Count(item =>
                item.EquipmentType == EquipmentType.Package &&
                item.EquipmentId == vm.PackageId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            int bookedCount = _context.BookingItems.Count(item =>
                item.EquipmentType == EquipmentType.Package &&
                item.EquipmentId == vm.PackageId &&
                vm.DateFrom < item.DateTo &&
                vm.DateTo > item.DateFrom);

            if (cartCount + bookedCount >= 5)
            {
                ModelState.AddModelError(string.Empty, "Der er ikke flere af denne pakke ledige i dette tidsrum");
                return View(vm);
            }

            var cartItem = new CartItem
            {
                EquipmentType = EquipmentType.Package,
                EquipmentId = vm.PackageId,
                DateFrom = vm.DateFrom,
                DateTo = vm.DateTo,
                Price = vm.Price
            };

            cart.AddItem(cartItem);

            HttpContext.Session.SetObject("Cart", cart);
            TempData["ItemAdded"] = true;

            return RedirectToAction("SpecificPackage", new { id = vm.PackageId });
        }
    }
}