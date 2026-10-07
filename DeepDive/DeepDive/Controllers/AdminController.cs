using DeepDive.Enums;
using DeepDive.Models;
using DeepDive.Persistance;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application")]
    public class AdminController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBCDRepository _bcdRepository;
        private readonly IDivingSuitsRepository _divingSuitsRepository;
        private readonly IFinnsRepository _finnsRepository;
        private readonly IMask_SnorkelRepository _maskSnorkelRepository;
        private readonly IRegulatorSetRepository _regulatorSetRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IPackageRepository _packageRepository;
        public AdminController(IBookingRepository bookingRepository,IBCDRepository bcdRepository, IDivingSuitsRepository divingSuitsRepository, IFinnsRepository finnsRepository, IMask_SnorkelRepository maskSnorkelRepository, IRegulatorSetRepository regulatorSetRepository, ITankRepository tankRepository, IPackageRepository packageRepository)
        {
            _bookingRepository = bookingRepository;
            _bcdRepository = bcdRepository;
            _divingSuitsRepository = divingSuitsRepository;
            _finnsRepository = finnsRepository;
            _maskSnorkelRepository = maskSnorkelRepository;
            _regulatorSetRepository = regulatorSetRepository;
            _tankRepository = tankRepository;
            _packageRepository = packageRepository;

        }

        public async Task<IActionResult> Index(string search, bool showPast = false)
        {
            var bookings = await _bookingRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(search))
            {
                if (!showPast)
                {
                    bookings = bookings
                    .Where(b => b.BookingItems.Any(i => i.DateTo >= DateTime.Today))
                           .ToList();
                }
                ViewBag.ShowPast = showPast;
                bookings = bookings
                    .Where(b => b.ApplicationUser != null &&
                                b.ApplicationUser.Email.Contains(search))
            .ToList();
            }
            var vm = new AdminVM
            {
                Bookings = bookings,
                Equipment = new AllEquipmentViewData
                {
                    bcds = await _bcdRepository.GetAll(),
                    divingSuits = await _divingSuitsRepository.GetAll(),
                    finns = await _finnsRepository.GetAll(),
                    mask_Snorkels = await _maskSnorkelRepository.GetAll(),
                    regulatorSets = await _regulatorSetRepository.GetAll(),
                    tanks = await _tankRepository.GetAll(),
                    Packages = await _packageRepository.GetAll(),
                }
            };
            return View(vm);
        }

        public async Task<IActionResult> EditBookingItem(int id)
        {
            var item = await _bookingRepository.GetItemById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditBookingItem(BookingItem item)
        {
            ModelState.Remove("Booking");

            if (item.DateTo <= item.DateFrom)
                ModelState.AddModelError("DateTo", "Slutdato skal være efter startdato.");

            if (!ModelState.IsValid) return View(item);

            try
            {
                await _bookingRepository.UpdateItem(item);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var dbValues = ex.Entries.Single().GetDatabaseValues();

                if (dbValues == null)
                {
                    ModelState.AddModelError(string.Empty, "Bookingen er blevet slettet af en anden bruger.");
                    return View(item);
                }

                var dbItem = (BookingItem)dbValues.ToObject();

                ModelState.AddModelError(string.Empty,
                    "Bookingen er blevet ændret af en anden bruger. " +
                    $"Nuværende værdier: {dbItem.DateFrom:dd-MM-yyyy} – {dbItem.DateTo:dd-MM-yyyy}, {dbItem.Price} kr. " +
                    "Tryk Gem igen for at overskrive.");

                item.RowVersion = dbItem.RowVersion;
                ModelState.Remove("RowVersion");

                return View(item);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBookingItem(int id)
        {
            await _bookingRepository.DeleteItem(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditTank(int id)
        {
            var tank = await _tankRepository.GetById(id);

            if (tank == null) 
                return NotFound();

            return View(tank);
        }

        [HttpPost]
        public async Task<IActionResult> EditTank(Tank tank)
        {
            RemoveDateErrors();
            if (!ModelState.IsValid) 
                return View(tank);

            if (Request.Form.Files.Count > 0)
            {
                var upload = Request.Form.Files[0];
                if (upload != null && upload.Length > 0)
                {
                    using var ms = new MemoryStream();
                    upload.CopyTo(ms);
                    tank.ImageData = ms.ToArray();
                    tank.ImageMimeType = upload.ContentType;
                }
            }

            if (tank.TankId == 0)
            {
                await _tankRepository.Add(tank);      
            }
            else
            {
                await _tankRepository.Update(tank);   
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTank(int id)
        {
            _tankRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // ---------- BCD ----------
        public async Task<IActionResult> EditBCD(int id)
        {
            var bcd = await _bcdRepository.GetById(id);
            if (bcd == null) return NotFound();
            return View(bcd);
        }

        [HttpPost]
        public async Task<IActionResult> EditBCD(BCD bcd, IFormFile? upload)
        {
            RemoveDateErrors();

            if (upload != null && upload.Length > 0)
            {
                using var ms = new MemoryStream();
                upload.CopyTo(ms);
                bcd.ImageData = ms.ToArray();
                bcd.ImageMimeType = upload.ContentType;
            }

            if (!ModelState.IsValid) return View(bcd);
            if (bcd.BCDId == 0)
                _bcdRepository.Add(bcd);
            else
                _bcdRepository.Update(bcd);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteBCD(int id)
        {
            _bcdRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // ---------- Finns ----------
        public async Task<IActionResult> EditFinns(int id)
        {
            var finn = await _finnsRepository.GetById(id);
            if (finn == null) return NotFound();
            return View(finn);
        }
        [HttpPost]
        public async Task<IActionResult> EditFinns(Finns finn, IFormFile? upload)
        {
            RemoveDateErrors();

            if (upload != null && upload.Length > 0)
            {
                using var ms = new MemoryStream();
                upload.CopyTo(ms);
                finn.ImageData = ms.ToArray();
                finn.ImageMimeType = upload.ContentType;
            }

            if (!ModelState.IsValid) return View(finn);
            if (finn.FinnsId == 0)
                await _finnsRepository.Add(finn);
            else
                await _finnsRepository.Update(finn);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteFinns(int id)
        {
            _finnsRepository.Delete(id);
            return RedirectToAction("Index");
        }
        // ---------- DivingSuits ----------
        public async Task<IActionResult> EditDivingSuits(int id)
        {
            var ds = await _divingSuitsRepository.GetById(id);
            if (ds == null) return NotFound();
            return View(ds);
        }

        [HttpPost]
        public async Task<IActionResult> EditDivingSuits(DivingSuits ds, IFormFile? upload)
        {
            RemoveDateErrors();

            if (upload != null && upload.Length > 0)
            {
                using var ms = new MemoryStream();
                upload.CopyTo(ms);
                ds.ImageData = ms.ToArray();
                ds.ImageMimeType = upload.ContentType;
            }

            if (!ModelState.IsValid) return View(ds);
            if (ds.DivingSuitsId == 0)
                await _divingSuitsRepository.Add(ds);
            else
                await _divingSuitsRepository.Update(ds);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteDivingSuits(int id)
        {
            _divingSuitsRepository.Delete(id);
            return RedirectToAction("Index");
        }
        // ---------- Mask/snorkel ----------
        public async Task<IActionResult> EditMask_Snorkel(int id)
        {
            var ms = await _maskSnorkelRepository.GetById(id);
            if (ms == null) return NotFound();
            return View(ms);
        }

        [HttpPost]
        public async Task<IActionResult> EditMask_Snorkel(Mask_Snorkel ms, IFormFile? upload)
        {
            RemoveDateErrors();

            if (upload != null && upload.Length > 0)
            {
                using var msStream = new MemoryStream();
                upload.CopyTo(msStream);
                ms.ImageData = msStream.ToArray();
                ms.ImageMimeType = upload.ContentType;
            }

            if (!ModelState.IsValid) return View(ms);
            if (ms.Mask_SnorkelId == 0)
                await _maskSnorkelRepository.Add(ms);
            else
                await _maskSnorkelRepository.Update(ms);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteMask_Snorkel(int id)
        {
            _maskSnorkelRepository.Delete(id);
            return RedirectToAction("Index");
        }
        // ---------- RegulatorSet----------
        public async Task<IActionResult> EditRegulatorSet(int id)
        {
            var rs = await _regulatorSetRepository.GetById(id);
            if (rs == null) return NotFound();
            return View(rs);
        }

        [HttpPost]
        public async Task<IActionResult> EditRegulatorSet(RegulatorSet rs, IFormFile? upload)
        {
            RemoveDateErrors();

            if (upload != null && upload.Length > 0)
            {
                using var ms = new MemoryStream();
                upload.CopyTo(ms);
                rs.ImageData = ms.ToArray();
                rs.ImageMimeType = upload.ContentType;
            }

            if (!ModelState.IsValid) return View(rs);
            if (rs.RegulatorSetId == 0)
                await _regulatorSetRepository.Add(rs);
            else
                await _regulatorSetRepository.Update(rs);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteRegulatorSet(int id)
        {
            _regulatorSetRepository.Delete(id);
            return RedirectToAction("Index");
        }

      
        public IActionResult AddBCD()
        {
            return View("EditBCD", new BCD());
        }

        public IActionResult AddDivingSuits()
        {
            return View("EditDivingSuits", new DivingSuits());
        }

        public IActionResult AddFinns()
        {
            return View("EditFinns", new Finns());
        }

        public IActionResult AddMask_Snorkel()
        {
            return View("EditMask_Snorkel", new Mask_Snorkel());
        }

        public IActionResult AddRegulatorSet()
        {
            return View("EditRegulatorSet", new RegulatorSet());
        }

        public IActionResult AddTank()
        {
            return View("EditTank", new Tank());
        }

        private void RemoveDateErrors()
        {
            ModelState.Remove("DateFrom");
            ModelState.Remove("DateTo");
        }

        // ---------- Pakker ----------
        public IActionResult AddPackage()
        {
            return View("EditPackage", new Package());
        }

        public async Task<IActionResult> EditPackage(int id)
        {
            var package = await _packageRepository.GetById(id);
            if (package == null) return NotFound();
            return View(package);
        }

        [HttpPost]
        public async Task<IActionResult> EditPackage(Package package)
        {
            if (!ModelState.IsValid) return View(package);

            if (package.PackageId == 0)
                await _packageRepository.Add(package);
            else
                await _packageRepository.Update(package);

            return RedirectToAction("EditPackage", new { id = package.PackageId });
        }

        [HttpPost]
        public IActionResult DeletePackage(int id)
        {
            _packageRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddPackageItem(int packageId, EquipmentType equipmentType, int equipmentId)
        {
            _packageRepository.AddItem(packageId, equipmentType, equipmentId);
            return RedirectToAction("EditPackage", new { id = packageId });
        }

        [HttpPost]
        public IActionResult RemovePackageItem(int packageItemId, int packageId)
        {
            _packageRepository.RemoveItem(packageItemId);
            return RedirectToAction("EditPackage", new { id = packageId });
        }

    }
}
