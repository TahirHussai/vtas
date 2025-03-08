using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
   public interface ISectorsServices
    {
        public Task<CustomResponseDto> Get();
        public Task<CustomResponseDto> GetById(int id);
        public Task<CustomResponseDto> Add(SectorDto dto);
        public Task<CustomResponseDto> Upate(SectorDto dto);
        void Save();
    }
}
