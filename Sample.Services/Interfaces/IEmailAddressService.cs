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
        Task<CustomResponseDto> GetEmailAddressByIdAsync(int emailId);
        Task<CustomResponseDto> AddOrUpdateEmailAddressAsync(EmailAddressDto emailAddressDto);
        Task<CustomResponseDto> DeleteEmailAddressAsync(int emailId);
    }

}
