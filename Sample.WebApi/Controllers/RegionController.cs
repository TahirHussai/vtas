using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionRepository;
        private readonly ILogger<AccountController> _logger;
        public RegionController(IRegionService regionRepository, ILogger<AccountController> logger)
        {
            _regionRepository = regionRepository;
            _logger = logger;
        }
       
        [HttpGet]
        [Route("GetRegions")]
        public async Task<ActionResult<CustomResponseDto>> Get()
        {
            var response = new CustomResponseDto();
          
            _logger.LogInformation("Attempted Get All  Region");

            response = await _regionRepository.Get();
            _logger.LogInformation("Successfully got All  Region");

            return response;
        }

        [HttpGet("GetRegionById/{id}")]
        public async Task<ActionResult<CustomResponseDto>> GetById(int id)
        {
            var response = new CustomResponseDto();
            _logger.LogInformation("Attempted Get   Region");
            response = await _regionRepository.GetById(id);
            _logger.LogInformation("Successfully got   Region");

            return response;
        }
        [Route("AddRegion")]
        [HttpPost]

        public async Task<ActionResult<CustomResponseDto>> Post([FromBody] RegionDTO dto)
        {
            CustomResponseDto response = new CustomResponseDto();

            _logger.LogInformation(" Region  Attempt");
            response = await _regionRepository.Add(dto);
            _logger.LogInformation(" Region  Attempted");
            return response;
        }
        [Route("UpdateRegion")]
        [HttpPut]
        public async Task<ActionResult<CustomResponseDto>> Update([FromBody] RegionDTO dto)
        {
            CustomResponseDto response = new CustomResponseDto();

            _logger.LogInformation("Update ub Region  Attempt");
            response = await _regionRepository.Upate(dto);
            _logger.LogInformation("Update  Region  Attempted");
            return response;
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("DeleteRegionById/{id}")]
        public void Delete(int id)
        {
        }
        #region Assigned region
        [Route("AddAssignedRegion")]
        [HttpPost]

        public async Task<ActionResult<CustomResponseDto>> AssignedRegion([FromBody] UserAssignedRegionDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();

            _logger.LogInformation("Assigned Region  Attempt");
            response = await _regionRepository.AddAssignedRegion(dto);
            _logger.LogInformation("Assigned Region  Attempted");
            return response;
        }
        [Route("UpdateAssignedRegion")]
        [HttpPut]
        public async Task<ActionResult<CustomResponseDto>> UpdateAssignedRegion([FromBody] UserAssignedRegionDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();

            _logger.LogInformation("Update Assigned Region  Attempt");
            response = await _regionRepository.UpdateAssignedRegion(dto);
            _logger.LogInformation("Update  Assigned Region  Attempted");
            return response;
        }
        [HttpGet("GetAssignedRegionByUserId{UserId}")]
        public async Task<ActionResult<CustomResponseDto>> GetAssignedById(string UserId)
        {
            var response = new CustomResponseDto();
            _logger.LogInformation("Attempted Assigned Get   Region");
            response = await _regionRepository.GetAssignedRegionByUserId(UserId);
            _logger.LogInformation("Successfully got Assigned  Region");

            return response;
        }
        #endregion
    }
}
