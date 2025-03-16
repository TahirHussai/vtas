using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IEmailAddressService
    {
        Task<CustomResponseDto> GetEmailAddressByIdAsync(string emailId);
        Task<List<EmailAddressDto>> GetEmailAddressByUserIdAsync(string UserId);
        Task<CustomResponseDto> AddOrUpdateEmailAddressAsync(EmailAddressDto emailAddressDto);
        Task<CustomResponseDto> DeleteEmailAddressAsync(string emailId);
    }

}
