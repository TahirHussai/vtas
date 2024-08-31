using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        private readonly ILogger<PhoneController> _logger;

        public PhoneController(IPhoneService phoneService, ILogger<PhoneController> logger)
        {
            _phoneService = phoneService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetPhonesByUserId/{userId}")]
        public async Task<ActionResult<CustomResponseDto>> GetPhonesByUserId(string userId)
        {
            _logger.LogInformation($"GetPhonesByUserId endpoint called with UserId: {userId}.");
            try
            {
                var phones = await _phoneService.GetPhonesByUserIdAsync(userId);
                return phones.Any()
                    ? CreateResponse(true, "Phones fetched successfully.", phones)
                    : CreateResponse(false, "No records found.", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
            }
        }

        [HttpPost]
        [Route("CreatePhone")]
        public async Task<ActionResult<CustomResponseDto>> CreatePhone(CreatePhoneDto dto)
        {
            _logger.LogInformation("CreatePhone endpoint called.");
            try
            {
                var createdPhone = await _phoneService.AddPhoneAsync(dto);
                return CreateResponse(true, "Phone created successfully.", createdPhone);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
            }
        }

        [HttpPut]
        [Route("UpdatePhone")]
        public async Task<ActionResult<CustomResponseDto>> UpdatePhone(PhoneDto dto)
        {
            _logger.LogInformation("UpdatePhone endpoint called.");
            try
            {
                await _phoneService.UpdatePhoneAsync(dto);
                return CreateResponse(true, "Phone updated successfully.", dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
            }
        }

        [HttpDelete]
        [Route("DeletePhoneById/{id}")]
        public async Task<ActionResult<CustomResponseDto>> DeletePhoneById(int id)
        {
            _logger.LogInformation($"DeletePhoneById endpoint called with id: {id}.");
            try
            {
                var isDeleted = await _phoneService.DeletePhoneAsync(id);
                return isDeleted
                    ? CreateResponse(true, "Phone deleted successfully.", null)
                    : CreateResponse(false, "No record found.", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
            }
        }

        private CustomResponseDto CreateResponse(bool isSuccess, string message, object content)
        {
            return new CustomResponseDto
            {
                IsSuccess = isSuccess,
                Message = message,
                Obj = content
            };
        }
    }


}
