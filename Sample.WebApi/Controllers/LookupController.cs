using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        private readonly ILogger<LookupController> _logger;

        public LookupController(ILookupService lookupService, ILogger<LookupController> logger)
        {
            _lookupService = lookupService;
            _logger = logger;
        }

        [HttpGet("address-types")]
        public async Task<ActionResult> GetAllAddressTypes()
        {
            var response = await _lookupService.GetAllAddressTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("appl-file-types")]
        public async Task<ActionResult> GetAllApplFileTypes()
        {
            var response = await _lookupService.GetAllApplFileTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("email-types")]
        public async Task<ActionResult> GetAllEmailTypes()
        {
            var response = await _lookupService.GetAllEmailTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("ent-types")]
        public async Task<ActionResult> GetAllEntTypes()
        {
            var response = await _lookupService.GetAllEntTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("file-types")]
        public async Task<ActionResult> GetAllFileTypes()
        {
            var response = await _lookupService.GetAllFileTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("form-file-types")]
        public async Task<ActionResult> GetAllFormFileTypes()
        {
            var response = await _lookupService.GetAllFormFileTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("job-types")]
        public async Task<ActionResult> GetAllJobTypes()
        {
            var response = await _lookupService.GetAllJobTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("person-statuses")]
        public async Task<ActionResult> GetAllPersonStatuses()
        {
            var response = await _lookupService.GetAllPersonStatusesAsync();
            return HandleResponse(response);
        }

        [HttpGet("phone-types")]
        public async Task<ActionResult> GetAllPhoneTypes()
        {
            var response = await _lookupService.GetAllPhoneTypesAsync();
            return HandleResponse(response);
        }

        [HttpGet("prefixes")]
        public async Task<ActionResult> GetAllPrefixes()
        {
            var response = await _lookupService.GetAllPrefixesAsync();
            return HandleResponse(response);
        }

        [HttpGet("shift-types")]
        public async Task<ActionResult> GetAllShiftTypes()
        {
            var response = await _lookupService.GetAllShiftTypesAsync();
            return HandleResponse(response);
        }

        private ActionResult HandleResponse(CustomResponseDto response)
        {
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
