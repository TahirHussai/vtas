using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailAddressController : ControllerBase
    {
        private readonly IEmailAddressService _emailAddressService;
        private readonly ILogger<EmailAddressController> _logger;

        public EmailAddressController(IEmailAddressService emailAddressService, ILogger<EmailAddressController> logger)
        {
            _emailAddressService = emailAddressService;
            _logger = logger;
        }

        //[HttpGet]
        //[Route("GetEmailsByUserId/{userId}")]
        //public async Task<ActionResult<CustomResponseDto>> GetEmailsByUserId(string userId)
        //{
        //    _logger.LogInformation($"GetEmailsByUserId endpoint called with UserId: {userId}.");
        //    try
        //    {
        //        var emails = await _emailAddressService.GetEmailsByUserIdAsync(userId);
        //        return emails.Any()
        //            ? CreateResponse(true, "Emails fetched successfully.", emails)
        //            : CreateResponse(false, "No records found.", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while processing the request.");
        //        return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
        //    }
        //}

        //[HttpPost]
        //[Route("CreateEmail")]
        //public async Task<ActionResult<CustomResponseDto>> CreateEmail(EmailAddressDto dto)
        //{
        //    _logger.LogInformation("CreateEmail endpoint called.");
        //    try
        //    {
        //        var createdEmail = await _emailAddressService.AddEmailAsync(dto);
        //        return CreateResponse(true, "Email created successfully.", createdEmail);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while processing the request.");
        //        return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
        //    }
        //}

        //[HttpPut]
        //[Route("UpdateEmail")]
        //public async Task<ActionResult<CustomResponseDto>> UpdateEmail(EmailAddressDto dto)
        //{
        //    _logger.LogInformation("UpdateEmail endpoint called.");
        //    try
        //    {
        //        await _emailAddressService.UpdateEmailAsync(dto);
        //        return CreateResponse(true, "Email updated successfully.", dto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while processing the request.");
        //        return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
        //    }
           

        //}

        //[HttpDelete]
        //[Route("DeleteEmailById/{id}")]
        //public async Task<ActionResult<CustomResponseDto>> DeleteEmailById(int id)
        //{
        //    _logger.LogInformation($"DeleteEmailById endpoint called with id: {id}.");
        //    try
        //    {
        //        var isDeleted = await _emailAddressService.DeleteEmailAsync(id);
        //        return isDeleted
        //            ? CreateResponse(true, "Email deleted successfully.", null)
        //            : CreateResponse(false, "No record found.", null);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while processing the request.");
        //        return CreateResponse(false, $"An unexpected error occurred.{ex.Message}", null);
        //    }
         
        //}

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
