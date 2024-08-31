using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IAddressService
    {
        Task<CustomResponseDto> GetAddressByIdAsync(int addressId);
        Task<CustomResponseDto> AddOrUpdateAddressAsync(AddressDto addressDto);
        Task<CustomResponseDto> DeleteAddressAsync(int addressId);
        Task<CustomResponseDto> GetAddressByUserIdAsync(string userId);  // New method
    }

}
