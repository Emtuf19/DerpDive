using DeepDive.Models;
using DeepDive.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EquipmentAPIController : ControllerBase
    {
        private readonly IMask_SnorkelRepository _mask_SnorkelRepository;
        private readonly IBCDRepository _bcdRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IDivingSuitsRepository _divingSuitsRepository;
        private readonly IRegulatorSetRepository _regulatorSetRepository;
        private readonly IFinnsRepository _finnsRepository;

        public EquipmentAPIController(IMask_SnorkelRepository mask_SnorkelRepository, IBCDRepository bCDRepository, ITankRepository tankRepository, IDivingSuitsRepository divingSuitsRepository, IRegulatorSetRepository regulatorSetRepository, IFinnsRepository finnsRepository)
        {
            _mask_SnorkelRepository = mask_SnorkelRepository;
            _bcdRepository = bCDRepository;
            _tankRepository = tankRepository;
            _divingSuitsRepository = divingSuitsRepository;
            _regulatorSetRepository = regulatorSetRepository;
            _finnsRepository = finnsRepository;
        }

        //api/SpecifikEquipmentAPI/bcd
        [HttpGet("bcd")]
        public async Task<IActionResult> GetAllBcdAsync()
        {
            var bcd = await _bcdRepository.GetAll();
            if (bcd == null) return NotFound();

            return Ok(bcd);
        }


        //api/SpecifikEquipmentAPI/bcd/image
        [HttpGet("bcd/{id}/image")]
        public async Task<IActionResult> GetBcdImage(int id)
        {
            var bcd = await _bcdRepository.GetById(id);
            if (bcd == null || bcd.ImageData == null) return NotFound();
            return File(bcd.ImageData, bcd.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/divingsuits
        [HttpGet("divingsuits")]
        public async Task<IActionResult> GetAllDivingsuits()
        {
            var ds = await _divingSuitsRepository.GetAll();
            if (ds == null) return NotFound();
            
            return Ok(ds);
        }


        //api/SpecifikEquipmentAPI/divingsuits/image
        [HttpGet("divingsuits/image")]
        public async Task<IActionResult> GetDivingsuitsImage(int id)
        {
            var ds = await _divingSuitsRepository.GetById(id);
            if (ds == null || ds.ImageData == null) return NotFound();
            return File(ds.ImageData, ds.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/finns
        [HttpGet("finns")]
        public async Task<IActionResult> GetAllFinns()
        {
            var finns = await _finnsRepository.GetAll();
            if (finns == null) return NotFound();

            return Ok(finns);
        }


        //api/SpecifikEquipmentAPI/finns/image
        [HttpGet("finns/{id}/image")]
        public async Task<IActionResult> GetFinnsImage(int id)
        {
            var finns = await _finnsRepository.GetById(id);
            if (finns == null || finns.ImageData == null) return NotFound();
            return File(finns.ImageData, finns.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/mask_snorkel
        [HttpGet("mask_snorkel")]
        public async Task<IActionResult> GetAllMask_Snorkel()
        {
            var ms = await _mask_SnorkelRepository.GetAll();
            if (ms == null) return NotFound();

            return Ok(ms);
        }


        //api/SpecifikEquipmentAPI/mask_snorkel/image
        [HttpGet("mask_snorkel/{id}/image")]
        public async Task<IActionResult> GetMask_SnorkelImage(int id)
        {
            var ms = await _mask_SnorkelRepository.GetById(id);
            if (ms == null || ms.ImageData == null) return NotFound();
            return File(ms.ImageData, ms.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/regulatorset
        [HttpGet("regulatorset")]
        public async Task<IActionResult> GetAllRegulatorset()
        {
            var rs = await _regulatorSetRepository.GetAll();
            if (rs == null) return NotFound();

            return Ok(rs);
        }


        //api/SpecifikEquipmentAPI/regulatorset/image
        [HttpGet("regulatorset/{id}/image")]
        public async Task<IActionResult> GetRegulatorsetImage(int id)
        {
            var rs = await _regulatorSetRepository.GetById(id);
            if (rs == null || rs.ImageData == null) return NotFound();
            return File(rs.ImageData, rs.ImageMimeType ?? "application/octet-stream");
        }

        //api/SpecifikEquipmentAPI/tank
        [HttpGet("tank")]
        public async Task<IActionResult> GetAllTank()
        {
            var tank = await _tankRepository.GetAll();
            if (tank == null) return NotFound();

            return Ok(tank);
        }


        //api/SpecifikEquipmentAPI/tank/image
        [HttpGet("tank/{id}/image")]
        public async Task<IActionResult> GetTankImage(int id)
        {
            var tank = await _tankRepository.GetById(id);
            if (tank == null || tank.ImageData == null) return NotFound();
            return File(tank.ImageData, tank.ImageMimeType ?? "application/octet-stream");
        }
    }
}
