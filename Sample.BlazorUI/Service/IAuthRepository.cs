using Sample.DTOS;

namespace Sample.BlazorUI.Service
{
    public interface IAuthRepository
    {
      Task<bool> Login(LoginDTO dto);
        public Task<bool> Register(UserDto dto);
        public Task Logout();
        public Task<List<UserWithRolesDto>> GetUsersListWithRoles();
    }
}
