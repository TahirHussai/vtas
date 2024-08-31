using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtherDetailsController : ControllerBase
    {
        private readonly IOtherDetailsService _otherDetailsService;
        private readonly ILogger<OtherDetailsController> _logger;

        public OtherDetailsController(IOtherDetailsService otherDetailsService, ILogger<OtherDetailsController> logger)
        {
            _otherDetailsService = otherDetailsService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetOtherDetailsByUserId/{userId}")]
        public async Task<ActionResult<CustomResponseDto>> GetOtherDetailsByUserId(string userId)
        {
            var response = await _otherDetailsService.GetOtherDetailsByUserIdAsync(userId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        [Route("AddOrUpdateOtherDetails")]
        public async Task<ActionResult<CustomResponseDto>> AddOrUpdateOtherDetails([FromBody] OtherDetailsDto otherDetailsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new CustomResponseDto { IsSuccess = false, Message = "Invalid data", Obj = null });
            }

            var response = await _otherDetailsService.AddOrUpdateOtherDetailsAsync(otherDetailsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("DeleteOtherDetails/{id}")]
        public async Task<ActionResult<CustomResponseDto>> DeleteOtherDetails(string id)
        {
            var response = await _otherDetailsService.DeleteOtherDetailsAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }

}
