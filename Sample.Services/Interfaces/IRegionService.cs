using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IRegionService
    {
        public Task<CustomResponseDto> Get();
        public Task<CustomResponseDto> GetById(int id);
        public Task<CustomResponseDto> Add(RegionDTO dto);
        public Task<CustomResponseDto> Upate(RegionDTO dto);
        void Save();

        public Task<CustomResponseDto> GetAssignedRegionById(int Id);
        public Task<CustomResponseDto> GetAssignedRegionByUserId(string UserId);
        public Task<CustomResponseDto> AddAssignedRegion(UserAssignedRegionDto dto);
        public Task<CustomResponseDto> UpdateAssignedRegion(UserAssignedRegionDto dto);
    }
}
