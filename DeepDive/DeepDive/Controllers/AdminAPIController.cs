using DeepDive.Models;
using DeepDive.Persistance;
using DeepDive.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeepDive.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminAPIController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBCDRepository _bcdRepository;
        private readonly IDivingSuitsRepository _divingSuitsRepository;
        private readonly IFinnsRepository _finnsRepository;
        private readonly IMask_SnorkelRepository _maskSnorkelRepository;
        private readonly IRegulatorSetRepository _regulatorSetRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IPackageRepository _packageRepository;

        public AdminAPIController(IBookingRepository bookingRepository, IBCDRepository bcdRepository, IDivingSuitsRepository divingSuitsRepository, IFinnsRepository finnsRepository, IMask_SnorkelRepository maskSnorkelRepository, IRegulatorSetRepository regulatorSetRepository, ITankRepository tankRepository, IPackageRepository packageRepository)
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

        // GET api/admin
        [HttpGet]
        public async Task<ActionResult<AdminVM>> GetAll(string? search)
        {
            var bookings = await _bookingRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(search))
            {
                bookings = bookings.Where(b => b.ApplicationUser != null && b.ApplicationUser.Email.Contains(search)).ToList();
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

            return Ok(vm);
        }

        // Booking item endpoints
        [HttpGet("bookingitem/{id}")]
        public async Task<ActionResult<BookingItem?>> GetBookingItem(int id)
        {
            var item = await _bookingRepository.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("bookingitem/{id}")]
        public async Task<IActionResult> UpdateBookingItem(int id, [FromBody] BookingItem item)
        {
            if (id != item.BookingItemId) return BadRequest();

            if (item.DateTo <= item.DateFrom)
                return BadRequest(new { error = "Slutdato skal være efter startdato." });

            try
            {
                await _bookingRepository.UpdateItem(item);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Conflict(new { error = "Concurrency error.", detail = ex.Message });
            }
        }

        [HttpDelete("bookingitem/{id}")]
        public async Task<IActionResult> DeleteBookingItem(int id)
        {
            await _bookingRepository.DeleteItem(id);
            return NoContent();
        }

        [HttpDelete("booking/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingRepository.Delete(id);
            return NoContent();
        }

        // BCD CRUD
        [HttpGet("bcd/{id}")]
        public async Task<ActionResult<BCD?>> GetBcd(int id)
        {
            var bcd = await _bcdRepository.GetById(id);
            if (bcd == null) return NotFound();
            return Ok(bcd);
        }

        [HttpPost("bcd")]
        public async Task<IActionResult> CreateOrUpdateBcd([FromBody] BCD bcd)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (bcd.BCDId == 0) await _bcdRepository.Add(bcd); else await _bcdRepository.Update(bcd);
            return Ok(bcd);
        }

        [HttpDelete("bcd/{id}")]
        public async Task<IActionResult> DeleteBcd(int id)
        {
            await _bcdRepository.Delete(id);
            return NoContent();
        }

        // Finns
        [HttpGet("finns/{id}")]
        public async Task<ActionResult<Finns?>> GetFinns(int id)
        {
            var f = await _finnsRepository.GetById(id);
            if (f == null) return NotFound();
            return Ok(f);
        }

        [HttpPost("finns")]
        public async Task<IActionResult> CreateOrUpdateFinns([FromBody] Finns f)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (f.FinnsId == 0) await _finnsRepository.Add(f); else await _finnsRepository.Update(f);
            return Ok(f);
        }

        [HttpDelete("finns/{id}")]
        public async Task<IActionResult> DeleteFinns(int id)
        {
            await _finnsRepository.Delete(id);
            return NoContent();
        }

        // DivingSuits
        [HttpGet("divingsuits/{id}")]
        public async Task<ActionResult<DivingSuits?>> GetDivingSuits(int id)
        {
            var ds = await _divingSuitsRepository.GetById(id);
            if (ds == null) return NotFound();
            return Ok(ds);
        }

        [HttpPost("divingsuits")]
        public async Task<IActionResult> CreateOrUpdateDivingSuits([FromBody] DivingSuits ds)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (ds.DivingSuitsId == 0) await _divingSuitsRepository.Add(ds); else await _divingSuitsRepository.Update(ds);
            return Ok(ds);
        }

        [HttpDelete("divingsuits/{id}")]
        public async Task<IActionResult> DeleteDivingSuits(int id)
        {
            await _divingSuitsRepository.Delete(id);
            return NoContent();
        }

        // Mask
        [HttpGet("mask/{id}")]
        public async Task<ActionResult<Mask_Snorkel?>> GetMask(int id)
        {
            var ms = await _maskSnorkelRepository.GetById(id);
            if (ms == null) return NotFound();
            return Ok(ms);
        }

        [HttpPost("mask")]
        public async Task<IActionResult> CreateOrUpdateMask([FromBody] Mask_Snorkel ms)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (ms.Mask_SnorkelId == 0) await _maskSnorkelRepository.Add(ms); else await _maskSnorkelRepository.Update(ms);
            return Ok(ms);
        }

        [HttpDelete("mask/{id}")]
        public async Task<IActionResult> DeleteMask(int id)
        {
            await _maskSnorkelRepository.Delete(id);
            return NoContent();
        }

        // Regulator
        [HttpGet("regulator/{id}")]
        public async Task<ActionResult<RegulatorSet?>> GetRegulator(int id)
        {
            var rs = await _regulatorSetRepository.GetById(id);
            if (rs == null) return NotFound();
            return Ok(rs);
        }

        [HttpPost("regulator")]
        public async Task<IActionResult> CreateOrUpdateRegulator([FromBody] RegulatorSet rs)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (rs.RegulatorSetId == 0) await _regulatorSetRepository.Add(rs); else await _regulatorSetRepository.Update(rs);
            return Ok(rs);
        }

        [HttpDelete("regulator/{id}")]
        public async Task<IActionResult> DeleteRegulator(int id)
        {
            await _regulatorSetRepository.Delete(id);
            return NoContent();
        }

        // Tank
        [HttpGet("tank/{id}")]
        public async Task<ActionResult<Tank?>> GetTank(int id)
        {
            var t = await _tankRepository.GetById(id);
            if (t == null) return NotFound();
            return Ok(t);
        }

        [HttpPost("tank")]
        public async Task<IActionResult> CreateOrUpdateTank([FromBody] Tank t)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (t.TankId == 0) await _tankRepository.Add(t); else await _tankRepository.Update(t);
            return Ok(t);
        }

        [HttpDelete("tank/{id}")]
        public async Task<IActionResult> DeleteTank(int id)
        {
            await _tankRepository.Delete(id);
            return NoContent();
        }

        // Package endpoints
        [HttpGet("package/{id}")]
        public async Task<ActionResult<Package?>> GetPackage(int id)
        {
            var p = await _packageRepository.GetById(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost("package")]
        public async Task<IActionResult> CreateOrUpdatePackage([FromBody] Package p)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (p.PackageId == 0) await _packageRepository.Add(p); else await _packageRepository.Update(p);
            return Ok(p);
        }

        [HttpDelete("package/{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            await _packageRepository.Delete(id);
            return NoContent();
        }

        [HttpPost("package/{packageId}/add/{equipmentType}/{equipmentId}")]
        public async Task<IActionResult> AddPackageItem(int packageId, DeepDive.Enums.EquipmentType equipmentType, int equipmentId)
        {
            await _packageRepository.AddItem(packageId, equipmentType, equipmentId);
            return NoContent();
        }

        [HttpPost("package/{packageId}/remove/{packageItemId}")]
        public async Task<IActionResult> RemovePackageItem(int packageId, int packageItemId)
        {
            await _packageRepository.RemoveItem(packageItemId);
            return NoContent();
        }
    }
}
