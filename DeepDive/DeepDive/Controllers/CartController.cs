using DeepDive.Extensions;
using DeepDive.Models;
using DeepDive.Persistance;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DeepDive.Enums;

namespace DeepDive.Controllers
{
    public class CartController : Controller
    {
        private readonly IDivingSuitsRepository _divingSuitsRepository;
        private readonly IBCDRepository _bcdRepository;
        private readonly IMask_SnorkelRepository _maskSnorkelRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IRegulatorSetRepository _regulatorSetRepository;
        private readonly IFinnsRepository _finnsRepository;

        public CartController(IDivingSuitsRepository divingSuitsRepository, IBCDRepository bcdRepository, IMask_SnorkelRepository maskSnorkelRepository, ITankRepository tankRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository)
        {
            _divingSuitsRepository = divingSuitsRepository;
            _bcdRepository = bcdRepository;
            _maskSnorkelRepository = maskSnorkelRepository;
            _tankRepository = tankRepository;
            _regulatorSetRepository = regulatorSetRepository;
            _finnsRepository = finnsRepository;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            var vm = new CartVM();

            foreach (var item in cart.Items)
            {
                if (item.EquipmentType == EquipmentType.DivingSuits)
                {
                    var divingSuit = _divingSuitsRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.BCD)
                {
                    var bcd = _bcdRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.Finns)
                {
                    var finns = _finnsRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.Mask_Snorkel)
                {
                    var maskSnorkel = _maskSnorkelRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.RegulatorSet)
                {
                    var regulatorSet = _regulatorSetRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.Tank)
                {
                    var tank = _tankRepository.GetById(item.EquipmentId);

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
                }
            }

            return View(vm);
        }

        //Virker ikke rigtigt. Fjerner første i listen!
        [HttpPost]
        public IActionResult Remove(int cartItemId)
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart != null)
            {
                var item = cart.Items.FirstOrDefault(
                    x => x.CartItemId == cartItemId);

                if (item != null)
                {
                    cart.Items.Remove(item);
                    HttpContext.Session.SetObject("Cart", cart);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
            }

            var vm = new CartVM();

            foreach (var item in cart.Items)
            {
                if (item.EquipmentType == EquipmentType.DivingSuits)
                {
                    var divingSuit = _divingSuitsRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.BCD)
                {
                    var bcd = _bcdRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.Finns)
                {
                    var finns = _finnsRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.Mask_Snorkel)
                {
                    var maskSnorkel = _maskSnorkelRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.RegulatorSet)
                {
                    var regulatorSet = _regulatorSetRepository.GetById(item.EquipmentId);

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
                }
                else if (item.EquipmentType == EquipmentType.Tank)
                {
                    var tank = _tankRepository.GetById(item.EquipmentId);

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
                }
            }
            return View(vm);
        }
    }
}
