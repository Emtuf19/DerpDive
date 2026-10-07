using DeepDive.Data;
using DeepDive.Enums;
using DeepDive.Extensions;
using DeepDive.Models;
using DeepDive.Persistance;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartAPIController : ControllerBase
    {
        private readonly IDivingSuitsRepository _divingSuitsRepository;
        private readonly IBCDRepository _bcdRepository;
        private readonly IMask_SnorkelRepository _maskSnorkelRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IRegulatorSetRepository _regulatorSetRepository;
        private readonly IFinnsRepository _finnsRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPackageRepository _packageRepository;
        private readonly EquipmentContext _context;

        public CartAPIController(IDivingSuitsRepository divingSuitsRepository, IBCDRepository bcdRepository, IMask_SnorkelRepository maskSnorkelRepository, ITankRepository tankRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository, EquipmentContext context, UserManager<ApplicationUser> userManager, IPackageRepository packageRepository)
        {
            _divingSuitsRepository = divingSuitsRepository;
            _bcdRepository = bcdRepository;
            _maskSnorkelRepository = maskSnorkelRepository;
            _tankRepository = tankRepository;
            _regulatorSetRepository = regulatorSetRepository;
            _finnsRepository = finnsRepository;
            _userManager = userManager;
            _packageRepository = packageRepository;

            _context = context;
        }

        // GET api/cart
        [HttpGet]
        public async Task<ActionResult<CartVM>> Get()
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            var vm = new CartVM();

            foreach (var item in cart.Items)
            {
                switch (item.EquipmentType)
                {
                    case EquipmentType.DivingSuits:
                        var divingSuit = await _divingSuitsRepository.GetById(item.EquipmentId);
                        if (divingSuit != null)
                        {
                            vm.Items.Add(new CartItemVM
                            {
                                CartItemId = item.CartItemId,
                                EquipmentType = EquipmentType.DivingSuits,
                                EquipmentId = divingSuit.DivingSuitsId,
                                Brand = divingSuit.Brand,
                                Model = divingSuit.Model,
                                SelectedGender = item.SelectedGender,
                                SelectedSize = item.SelectedSize,
                                Thickness = divingSuit.Thickness,
                                Type = divingSuit.Type,
                                DateFrom = item.DateFrom,
                                DateTo = item.DateTo,
                                Price = item.Price
                            });
                        }
                        break;
                    case EquipmentType.BCD:
                        var bcd = await _bcdRepository.GetById(item.EquipmentId);
                        if (bcd != null)
                        {
                            vm.Items.Add(new CartItemVM
                            {
                                CartItemId = item.CartItemId,
                                EquipmentType = EquipmentType.BCD,
                                EquipmentId = bcd.BCDId,
                                Brand = bcd.Brand,
                                Model = bcd.Model,
                                SelectedSize = item.SelectedSize,
                                DateFrom = item.DateFrom,
                                DateTo = item.DateTo,
                                Price = item.Price
                            });
                        }
                        break;
                    case EquipmentType.Finns:
                        var finns = await _finnsRepository.GetById(item.EquipmentId);
                        if (finns != null)
                        {
                            vm.Items.Add(new CartItemVM
                            {
                                CartItemId = item.CartItemId,
                                EquipmentType = EquipmentType.Finns,
                                EquipmentId = finns.FinnsId,
                                Brand = finns.Brand,
                                Model = finns.Model,
                                SelectedSize = item.SelectedSize,
                                DateFrom = item.DateFrom,
                                DateTo = item.DateTo,
                                Price = item.Price
                            });
                        }
                        break;
                    case EquipmentType.Mask_Snorkel:
                        var maskSnorkel = await _maskSnorkelRepository.GetById(item.EquipmentId);
                        if (maskSnorkel != null)
                        {
                            vm.Items.Add(new CartItemVM
                            {
                                CartItemId = item.CartItemId,
                                EquipmentType = EquipmentType.Mask_Snorkel,
                                EquipmentId = maskSnorkel.Mask_SnorkelId,
                                Brand = maskSnorkel.Brand,
                                Model = maskSnorkel.Model,
                                DateFrom = item.DateFrom,
                                DateTo = item.DateTo,
                                Price = item.Price
                            });
                        }
                        break;
                    case EquipmentType.RegulatorSet:
                        var regulatorSet = await _regulatorSetRepository.GetById(item.EquipmentId);
                        if (regulatorSet != null)
                        {
                            vm.Items.Add(new CartItemVM
                            {
                                CartItemId = item.CartItemId,
                                EquipmentType = EquipmentType.RegulatorSet,
                                EquipmentId = regulatorSet.RegulatorSetId,
                                Brand = regulatorSet.Brand,
                                FirstStep = regulatorSet.FirstStep,
                                SecondStep = regulatorSet.SecondStep,
                                Octopus = regulatorSet.Octopus,
                                DateFrom = item.DateFrom,
                                DateTo = item.DateTo,
                                Price = item.Price
                            });
                        }
                        break;
                    case EquipmentType.Tank:
                        var tank = await _tankRepository.GetById(item.EquipmentId);
                        if (tank != null)
                        {
                            vm.Items.Add(new CartItemVM
                            {
                                CartItemId = item.CartItemId,
                                EquipmentType = EquipmentType.Tank,
                                EquipmentId = tank.TankId,
                                Brand = tank.Brand,
                                Volumen = tank.Volumen,
                                DateFrom = item.DateFrom,
                                DateTo = item.DateTo,
                                Price = item.Price
                            });
                        }
                        break;
                    case EquipmentType.Package:
                        var package = await _packageRepository.GetById(item.EquipmentId);
                        if (package != null)
                        {
                            vm.Items.Add(new CartItemVM
                            {
                                CartItemId = item.CartItemId,
                                EquipmentType = EquipmentType.Package,
                                EquipmentId = package.PackageId,
                                Brand = package.Title,
                                Model = package.Title,
                                DateFrom = item.DateFrom,
                                DateTo = item.DateTo,
                                Price = item.Price
                            });
                        }
                        break;
                }
            }

            return Ok(vm);
        }

        // POST api/cart/remove/{id}
        [HttpPost("remove/{cartItemId}")]
        public ActionResult Remove(int cartItemId)
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart != null)
            {
                var item = cart.Items.FirstOrDefault(x => x.CartItemId == cartItemId);
                if (item != null)
                {
                    cart.Items.Remove(item);
                    HttpContext.Session.SetObject("Cart", cart);
                    return NoContent();
                }
            }

            return NotFound();
        }

        // GET api/cart/checkout
        [HttpGet("checkout")]
        public async Task<ActionResult<CartVM>> Checkout()
        {
            return await Get();
        }

        // POST api/cart/confirm
        [Authorize]
        [HttpPost("confirm")]
        public async Task<ActionResult> ConfirmCheckout()
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null || !cart.Items.Any())
            {
                return BadRequest(new { error = "Din kurv er tom." });
            }

            var booking = new Booking()
            {
                ApplicationUserId = _userManager.GetUserId(User)
            };

            foreach (var item in cart.Items)
            {
                var bookingItem = new BookingItem
                {
                    EquipmentType = item.EquipmentType,
                    EquipmentId = item.EquipmentId,
                    SelectedSize = item.SelectedSize,
                    SelectedGender = item.SelectedGender,
                    Price = item.Price,
                    DateFrom = item.DateFrom,
                    DateTo = item.DateTo
                };

                booking.BookingItems.Add(bookingItem);
            }

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("Cart");

            return Ok(new { message = "Din booking er gennemført!", bookingId = booking.BookingId });
        }
    }
}
