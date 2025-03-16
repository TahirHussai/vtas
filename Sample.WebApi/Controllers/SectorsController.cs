using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorsServices _sectorsServices;
        private readonly ILogger<AccountController> _logger;
        public SectorsController(ISectorsServices sectorRepository, ILogger<AccountController> logger)
        {
            _sectorsServices = sectorRepository;
            _logger = logger;
        }
        [HttpGet("GetSectors")]
        public async Task<ActionResult<CustomResponseDto>> Get()
        {
            var response = new CustomResponseDto();
            _logger.LogInformation("Attempted Get All Sector");

            response = await _sectorsServices.Get();
            _logger.LogInformation("Successfully got All Sector");

            return response;
        }

        [HttpGet("GetSectorById/{id}")]
        public async Task<ActionResult<CustomResponseDto>> GetById(int id)
        {
            var response = new CustomResponseDto();
            _logger.LogInformation("Attempted Get Sector");
            response = await _sectorsServices.GetById(id);
            _logger.LogInformation("Successfully got  Sector");

            return response;
        }
        [Route("AddSector")]
        [HttpPost]
        public async Task<ActionResult<CustomResponseDto>> Post([FromBody] SectorDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();

            _logger.LogInformation("Sector Attempt");
            response = await _sectorsServices.Add(dto);
            _logger.LogInformation("Sector  Attempted");
            return response;
        }
        [Route("UpdateSector")]
        [HttpPut]
        public async Task<ActionResult<CustomResponseDto>> Update([FromBody] SectorDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();

            _logger.LogInformation("Update Sector  Attempt");
            response = await _sectorsServices.Upate(dto);
            _logger.LogInformation("Update Sector  Attempted");
            return response;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
