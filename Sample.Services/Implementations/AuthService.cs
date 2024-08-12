using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sample.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserPofile> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            UserManager<UserPofile> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IUserService userService,
            IConfiguration configuration,
            JwtSecurityTokenHandler jwtSecurityTokenHandler,
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _logger = logger;
        }

        public async Task<CustomResponseDto> LoginUser(LoginDTO userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password))
            {
                _logger.LogWarning($"Invalid login attempt for {userDto.Email}");
                return new CustomResponseDto { IsSuccess = false, Message = "Invalid credentials" };
            }

            var token = await GenerateToken(user);
            var role = _roleManager.FindByNameAsync(userDto.Role);
            return new CustomResponseDto
            {
                IsSuccess = true,
                Message = "Login successful",
                Obj = new ResponseDto
                {
                    Token = token,
                    Email = user.Email,
                    UserName = $"{user.FirstName} {user.Lastname}",
                    Role = role.ToString(),
                }
            };
        }

        public async Task<CustomResponseDto> RegisterUser(UserDto userDto)
        {
            var user = _mapper.Map<UserPofile>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                _logger.LogError($"Failed to register user {userDto.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                return new CustomResponseDto { IsSuccess = false, Message = $"Failed to register user: {string.Join(", ", result.Errors.Select(e => e.Description))}" };
            }

            await _userManager.AddToRoleAsync(user, userDto.RoleName);
            var role = await _roleManager.FindByNameAsync(userDto.RoleName);
            if (role != null)
            {
                var userRole = new AspNetUserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    AccessLevelID = 1,
                    CreateByID = user.Id,
                    CreatedDate = DateTime.UtcNow,
                    PersonStatusID = 1,
                    UpdatedByID = user.Id,
                    UpdatedDate = DateTime.UtcNow
                };
                await _userService.AddUserRoleAsync(userRole);
            }

            return new CustomResponseDto { IsSuccess = true, Message = "Registration successful" };
        }

        public async Task<CustomResponseDto> GetUserById(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                return new CustomResponseDto { IsSuccess = true, Message = "User retrieved successfully", Obj = _mapper.Map<UserDto>(user) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving user {userId}");
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> GetAllUsersWithRoles()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                return new CustomResponseDto { IsSuccess = true, Message = "Users retrieved successfully", Obj = await MapUsersToRoles(users) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users");
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> GetCustomerUsersWithRoles(string customerId)
        {
            try
            {
                var users = await _userManager.Users.Where(u => u.CustomerId == customerId).ToListAsync();
                return new CustomResponseDto { IsSuccess = true, Message = "Users retrieved successfully", Obj = await MapUsersToRoles(users) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving users for customer {customerId}");
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> GetClientUsersWithRoles(string clientId, string customerId)
        {
            try
            {
                var users = await _userManager.Users.Where(u => u.CustomerId == customerId && u.CreatedById == clientId).ToListAsync();
                return new CustomResponseDto { IsSuccess = true, Message = "Users retrieved successfully", Obj = await MapUsersToRoles(users) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving users for client {clientId} and customer {customerId}");
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> GetVendorsUsersWithRoles(string vendorId, string customerId)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.CreatedById == vendorId && u.CustomerId == customerId);
                return new CustomResponseDto { IsSuccess = true, Message = "User retrieved successfully", Obj = await MapUserToRole(user) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving user for vendor {vendorId} and customer {customerId}");
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> GetRecruiterUsersWithRoles(string recruiterId, string customerId)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.CreatedById == recruiterId && u.Id == recruiterId && u.CustomerId == customerId);
                return new CustomResponseDto { IsSuccess = true, Message = "User retrieved successfully", Obj = await MapUserToRole(user) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving user for recruiter {recruiterId} and customer {customerId}");
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        private async Task<string> GenerateToken(UserPofile user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSetting:IssuerSigningKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.Lastname}"),
            new Claim("ProfileImage", user.ProfilePicture),
            new Claim("LoginUserId", user.Id),
            new Claim("ParentId", user.ParentId),
            new Claim("CustomerId", user.CustomerId)
        };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSetting:ValidIssuer"],
                audience: _configuration["JwtSetting:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        private async Task<IEnumerable<UserWithRoleDto>> MapUsersToRoles(IEnumerable<UserPofile> users)
        {
            var userRoles = new List<UserWithRoleDto>();
            foreach (var user in users)
            {
                userRoles.Add(await MapUserToRole(user));
            }
            return userRoles;
        }

        private async Task<UserWithRoleDto> MapUserToRole(UserPofile user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return new UserWithRoleDto
            {
                Id = user.Id,
                UserName = $"{user.FirstName} {user.Lastname}",
                Email = user.Email,
                Role = roles.ToString()
            };
        }
    }

}
