using Sample.Data;
using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IAuthService
    {
        Task<CustomResponseDto> LoginUser(LoginDTO userDto);
        Task<CustomResponseDto> RegisterUser(UserDto userDto);
        Task<CustomResponseDto> RegisterCustomer(UserCustomerDto userDto);
        Task<CustomResponseDto> RegisterClient(CreateClientDto userDto);
        Task<CustomResponseDto> AssignNewRole(UserRoleAssignmentDto userDto);
        Task<CustomResponseDto> GetUserById(string userId);
        Task<GetClientDto> GetClientById(string userId);
        Task<CustomResponseDto> GetAllUsersWithRoles();
        Task<CustomResponseDto> GetAllCustomerWithRoles();
        Task<CustomResponseDto> GetUsersWithRole();
        Task<CustomResponseDto> GetCustomerUsersWithRoles(string customerId);
        Task<CustomResponseDto> GetClientUsersWithRoles(string clientId, string customerId);
        Task<CustomResponseDto> GetVendorsUsersWithRoles(string vendorId, string customerId);
        Task<CustomResponseDto> GetRecruiterUsersWithRoles(string recruiterId, string customerId);
    }
}
