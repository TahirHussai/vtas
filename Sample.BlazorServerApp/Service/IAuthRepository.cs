using Sample.BlazorServerAPP.DTO;

namespace Sample.BlazorServerAPP.Service
{
    public interface IAuthRepository
    {
      Task<bool> Login(LoginDTO dto);
        public Task<bool> Register(UserDto dto);
        public Task Logout();
        Task<string> RefreshToken();
    }
}
