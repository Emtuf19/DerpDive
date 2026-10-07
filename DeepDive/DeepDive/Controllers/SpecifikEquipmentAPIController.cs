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
    [ApiController]
    [Route("api/[Controller]")]
    public class SpecifikEquipmentAPIController : ControllerBase
    {
        private readonly IMask_SnorkelRepository _mask_SnorkelRepository;
        private readonly IBCDRepository _bcdRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IDivingSuitsRepository _divingSuitsRepository;
        private readonly IRegulatorSetRepository _regulatorSetRepository;
        private readonly IFinnsRepository _finnsRepository;
        private readonly IPackageRepository _packageRepository;

        private readonly EquipmentContext _context;

        public SpecifikEquipmentAPIController(IMask_SnorkelRepository mask_SnorkelRepository, IBCDRepository bCDRepository, ITankRepository tankRepository, IDivingSuitsRepository divingSuitsRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository, EquipmentContext context, IPackageRepository packageRepository)
        {
            _mask_SnorkelRepository = mask_SnorkelRepository;
            _bcdRepository = bCDRepository;
            _tankRepository = tankRepository;
            _divingSuitsRepository = divingSuitsRepository;
            _regulatorSetRepository = regulatorSetRepository;
            _finnsRepository = finnsRepository;
            _packageRepository = packageRepository;

            _context = context;
        }

        //api/SpecifikEquipmentAPI/bcd/{id}
        [HttpGet("bcd/{id}")]
        public async Task<IActionResult> GetBcd(int id)
        {
            var bcd = await _bcdRepository.GetById(id);
            if (bcd == null) return NotFound();

            var dto = new
            {
                bcd.Brand,
                bcd.Model,
                bcd.Price,
                Sizes = bcd.Size,
                bcd.DateFrom,
                bcd.DateTo,
                ImageBase64 = bcd.ImageData != null ? Convert.ToBase64String(bcd.ImageData) : null,
                ImageMimeType = bcd.ImageMimeType
            };

            return Ok(dto);
        }


        //api/SpecifikEquipmentAPI/bcd/{id}/image
        [HttpGet("bcd/{id}/image")]
        public async Task<IActionResult> GetBcdImage(int id)
        {
            var bcd = await _bcdRepository.GetById(id);
            if (bcd == null || bcd.ImageData == null) return NotFound();
            return File(bcd.ImageData, bcd.ImageMimeType ?? "application/octet-stream");
        }


        //api/SpecifikEquipmentAPI/divingsuits/{id}
        [HttpGet("divingsuits/{id}")]
        public async Task<IActionResult> GetDivingSuits(int id)
        {
            var ds = await _divingSuitsRepository.GetById(id);
            if (ds == null) return NotFound();

            var dto = new
            {
                ds.DivingSuitsId,
                ds.Brand,
                ds.Model,
                ds.Price,
                Sizes = ds.Size,
                Genders = ds.Gender,
                ds.DateFrom,
                ds.DateTo,
                ImageBase64 = ds.ImageData != null ? Convert.ToBase64String(ds.ImageData) : null,
                ImageMimeType = ds.ImageMimeType
            };

            return Ok(dto);
        }

        //api/SpecifikEquipmentAPI/divingsuits/{id}/image
        [HttpGet("divingsuits/{id}/image")]
        public async Task<IActionResult> GetDivingSuitsImage(int id)
        {
            var ds = await _divingSuitsRepository.GetById(id);
            if (ds == null || ds.ImageData == null) return NotFound();
            return File(ds.ImageData, ds.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/finns/{id}
        [HttpGet("finns/{id}")]
        public async Task<IActionResult> GetFinns(int id)
        {
            var finns = await _finnsRepository.GetById(id);
            if (finns == null) return NotFound();

            var dto = new
            {
                finns.FinnsId,
                finns.Brand,
                finns.Model,
                finns.Price,
                finns.DateFrom,
                finns.DateTo,
                ImageBase64 = finns.ImageData != null ? Convert.ToBase64String(finns.ImageData) : null,
                ImageMimeType = finns.ImageMimeType
            };

            return Ok(dto);
        }

        //api/SpecifikEquipmentAPI/finns/{id}/image
        [HttpGet("finns/{id}/image")]
        public async Task<IActionResult> GetFinnsImage(int id)
        {
            var finns = await _finnsRepository.GetById(id);
            if (finns == null || finns.ImageData == null) return NotFound();
            return File(finns.ImageData, finns.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/mask_snorkel/{id}
        [HttpGet("mask_snorkel/{id}")]
        public async Task<IActionResult> GetMask_Snorkel(int id)
        {
            var ms = await _mask_SnorkelRepository.GetById(id);
            if (ms == null) return NotFound();

            var dto = new
            {
                ms.Mask_SnorkelId,
                ms.Brand,
                ms.Model,
                ms.Price,
                ms.DateFrom,
                ms.DateTo,
                ImageBase64 = ms.ImageData != null ? Convert.ToBase64String(ms.ImageData) : null,
                ImageMimeType = ms.ImageMimeType
            };

            return Ok(dto);
        }

        //api/SpecifikEquipmentAPI/mask_snorkel/{id}/image
        [HttpGet("mask_snorkel/{id}/image")]
        public async Task<IActionResult> GetMask_SnorkelImage(int id)
        {
            var ms = await _divingSuitsRepository.GetById(id);
            if (ms == null || ms.ImageData == null) return NotFound();
            return File(ms.ImageData, ms.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/regulatorset/{id}
        [HttpGet("regulatorset/{id}")]
        public async Task<IActionResult> GetRegulatorset(int id)
        {
            var rs = await _regulatorSetRepository.GetById(id);
            if (rs == null) return NotFound();

            var dto = new
            {
                rs.RegulatorSetId,
                rs.Brand,
                rs.FirstStep,
                rs.SecondStep,
                rs.Octopus,
                rs.Price,
                rs.DateFrom,
                rs.DateTo,
                ImageBase64 = rs.ImageData != null ? Convert.ToBase64String(rs.ImageData) : null,
                ImageMimeType = rs.ImageMimeType
            };

            return Ok(dto);
        }

        //api/SpecifikEquipmentAPI/regulatorset/{id}/image
        [HttpGet("regulatorset/{id}/image")]
        public async Task<IActionResult> GetRegulatorsetImage(int id)
        {
            var rs = await _divingSuitsRepository.GetById(id);
            if (rs == null || rs.ImageData == null) return NotFound();
            return File(rs.ImageData, rs.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/tank/{id}
        [HttpGet("tank/{id}")]
        public async Task<IActionResult> GetTank(int id)
        {
            var tank = await _tankRepository.GetById(id);
            if (tank == null) return NotFound();

            var dto = new
            {
                tank.TankId,
                tank.Brand,
                tank.Volumen,
                tank.Price,
                tank.DateFrom,
                tank.DateTo,
                ImageBase64 = tank.ImageData != null ? Convert.ToBase64String(tank.ImageData) : null,
                ImageMimeType = tank.ImageMimeType
            };

            return Ok(dto);
        }

        //api/SpecifikEquipmentAPI/tank/{id}/image
        [HttpGet("tank/{id}/image")]
        public async Task<IActionResult> GetTankImage(int id)
        {
            var tank = await _divingSuitsRepository.GetById(id);
            if (tank == null || tank.ImageData == null) return NotFound();
            return File(tank.ImageData, tank.ImageMimeType ?? "application/octet-stream");
        }
    }
}
