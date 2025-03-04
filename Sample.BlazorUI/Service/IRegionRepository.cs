using Sample.DTOS;

namespace Sample.BlazorUI.Service
{
    public interface IRegionRepository
    {
        public Task<List<RegionDTO>> Get();
        public Task<RegionDTO> GetById(int id);
        public Task<CustomResponseDto> Add(RegionDTO dto);
        public Task<CustomResponseDto> Upate(RegionDTO dto);
    }
}
