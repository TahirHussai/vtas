
namespace Sample.DTOS
{
    public class UserWithRoleDto
    {
        public string ParentId { get; set; }// ParentId is SuperAdminId
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
    public class UsersWithRolesDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
    public class UserRoleAssignmentDto
    {
        public string UserId { get; set; }
        public List<string> RoleIds { get; set; }
    }
    public class RoleDto
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsAssigned { get; set; }
    }
}
