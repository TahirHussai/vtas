using Sample.Data;
using Sample.Services.Interfaces;

namespace Sample.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly App_BlazorDBContext _context;

        public UserService(App_BlazorDBContext context)
        {
            _context = context;
        }

        public async Task AddUserRoleAsync( AspNetUserRole model)
        {
           
            _context.AspNetUserRoles.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
