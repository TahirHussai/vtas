using Sample.DTOS;

namespace Sample.BlazorUI.Service
{
    public interface IAuthRepository
    {
        Task<bool> Login(LoginDTO dto);
        public Task<bool> Register(UserDto dto);
        public Task Logout();
        public Task<List<UsersWithRolesDto>> GetUsersWithRolesAsync();
        public Task<List<UserWithRoleDto>> GetUsersListWithRole();
        public Task<bool> GetUserById(string UserId);
        public Task<List<UserWithRoleDto>> GetCustomerUsersListWithRoles(string CustomerId);
        public Task<List<UserWithRoleDto>> GetClientUsersWithRoles(string ClientId, string CustomerId);
        public Task<List<UserWithRoleDto>> GetVendorsUsersWithRoles(string VendorId, string CustomerId);
        public Task<List<UserWithRoleDto>> GetRecruiterUsersWithRoles(string RecruiterId, string CustomerId);
        public Task<bool> UpdateUserRoles(UserRoleAssignmentDto dto);
    }
}
