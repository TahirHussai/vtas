using Sample.DTOS;

namespace Sample.BlazorUI.Service
{
    public interface IAuthRepository
    {
        Task<bool> Login(LoginDTO dto);
        public Task<bool> Register(UserDto dto);
        public Task Logout();
        public Task<List<UserWithRolesDto>> GetUsersListWithRoles();
        public Task<bool> GetUserById(string UserId);
        public Task<List<UserWithRolesDto>> GetCustomerUsersListWithRoles(string CustomerId);
        public Task<List<UserWithRolesDto>> GetClientUsersWithRoles(string ClientId, string CustomerId);
        public Task<List<UserWithRolesDto>> GetVendorsUsersWithRoles(string VendorId, string CustomerId);
        public Task<List<UserWithRolesDto>> GetRecruiterUsersWithRoles(string RecruiterId, string CustomerId);
    }
}
