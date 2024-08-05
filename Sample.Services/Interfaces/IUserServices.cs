using Sample.Data;

namespace Sample.Services.Interfaces
{
    public interface IUserService
    {
        public  Task AddUserRoleAsync( AspNetUserRole model);
    }
}
