using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface ILookupService
    {
        Task<CustomResponseDto> GetAllAddressTypesAsync();
        Task<CustomResponseDto> GetAllApplFileTypesAsync();
        Task<CustomResponseDto> GetAllEmailTypesAsync();
        Task<CustomResponseDto> GetAllEntTypesAsync();
        Task<CustomResponseDto> GetAllFileTypesAsync();
        Task<CustomResponseDto> GetAllFormFileTypesAsync();
        Task<CustomResponseDto> GetAllJobTypesAsync();
        Task<CustomResponseDto> GetAllPersonStatusesAsync();
        Task<CustomResponseDto> GetAllPhoneTypesAsync();
        Task<CustomResponseDto> GetAllPrefixesAsync();
        Task<CustomResponseDto> GetAllShiftTypesAsync();
    }

}
