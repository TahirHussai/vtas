using Sample.BlazorUI.Repository.Interface;
using Sample.DTOS;

namespace Sample.BlazorUI.Services.Interface
{
    public interface ISectorServices : IBaseRepository<SectorDto>
    {
        public Task<CustomResponseDto> Get();
        public Task<CustomResponseDto> GetById(int id);
        public Task<CustomResponseDto> Add(SectorDto dto);
        public Task<CustomResponseDto> Upate(SectorDto dto);
    }
}
