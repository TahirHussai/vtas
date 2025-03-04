using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IRegionRepository
    {
        public Task<CustomResponseDto> Get();
        public Task<CustomResponseDto> GetById(int id);
        public Task<CustomResponseDto> Add(RegionDTO dto);
        public Task<CustomResponseDto> Upate(RegionDTO dto);
        void Save();
    }
}
