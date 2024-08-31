using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressesService;
        private readonly ILogger<AddressesController> _logger;

        public AddressesController(IAddressService addressesService, ILogger<AddressesController> logger)
        {
            _addressesService = addressesService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAddressesByUserId/{userId}")]
        public async Task<ActionResult<CustomResponseDto>> GetAddressesByUserId(string userId)
        {
            _logger.LogInformation($"GetAddressesByUserId endpoint called with UserId: {userId}.");
            try
            {
                var addresses = await _addressesService.GetAddressesByUserIdAsync(userId);
                return addresses.Any()
                    ? CreateResponse(true, "Addresses fetched successfully.", addresses)
                    : CreateResponse(false, "No records found.", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
            }
        }

        [HttpPost]
        [Route("CreateAddress")]
        public async Task<ActionResult<CustomResponseDto>> CreateAddress(CreateAddressDto dto)
        {
            _logger.LogInformation("CreateAddress endpoint called.");
            try
            {
                var createdAddress = await _addressesService.AddAddressAsync(dto);
                return CreateResponse(true, "Address created successfully.", createdAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
            }
        }

        [HttpPut]
        [Route("UpdateAddress")]
        public async Task<ActionResult<CustomResponseDto>> UpdateAddress(AddressDto dto)
        {
            _logger.LogInformation("UpdateAddress endpoint called.");
            try
            {
                await _addressesService.UpdateAddressAsync(dto);
                return CreateResponse(true, "Address updated successfully.", dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
            }
        }

        [HttpDelete]
        [Route("DeleteAddressById/{id}")]
        public async Task<ActionResult<CustomResponseDto>> DeleteAddressById(int id)
        {
            _logger.LogInformation($"DeleteAddressById endpoint called with id: {id}.");
            try
            {
                var isDeleted = await _addressesService.DeleteAddressAsync(id);
                return isDeleted
                    ? CreateResponse(true, "Address deleted successfully.", null)
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
