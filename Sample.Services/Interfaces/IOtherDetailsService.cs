using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IOtherDetailsService
    {
        Task<CustomResponseDto> GetOtherDetailsByUserIdAsync(string userId);
        Task<CustomResponseDto> AddOrUpdateOtherDetailsAsync(OtherDetailsDto otherDetailsDto);
        Task<CustomResponseDto> DeleteOtherDetailsAsync(string id);
    }

}
