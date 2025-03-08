using Sample.BlazorUI.Repository.Interface;
using Sample.DTOS;

namespace Sample.BlazorUI.Services.Interface
{
    public interface IRegionService : IBaseRepository<RegionDTO>
    {
        public Task<CustomResponseDto> Get();
        public Task<CustomResponseDto> GetById(int id);
        public Task<CustomResponseDto> Add(RegionDTO dto);
        public Task<CustomResponseDto> Upate(RegionDTO dto);
    }
}
