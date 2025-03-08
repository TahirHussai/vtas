using Sample.DTOS;

namespace Sample.BlazorUI.Repository.Interface
{

    public interface IBaseRepository<T> where T : class
    {
        Task<CustomResponseDto> Create(string url, T entity);
        Task<CustomResponseDto> Update(string url, int id, T entity);
        Task<CustomResponseDto> GetById(string url, int id);
        Task<CustomResponseDto> Delete(string url, int id);
        Task<CustomResponseDto> GetAll(string url);
        Task<bool> Save();
    }
}

