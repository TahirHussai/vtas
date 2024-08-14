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
        private readonly App_BlazorDBContext _context;


        public AuthService(
            UserManager<UserPofile> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IUserService userService,
            IConfiguration configuration,
            JwtSecurityTokenHandler jwtSecurityTokenHandler,
            ILogger<AuthService> logger,
            App_BlazorDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _logger = logger;
            _context = context;
        }


        public async Task<CustomResponseDto> LoginUser(LoginDTO userDto)
        {
            var Obj = new ResponseDto();
            var user = await _userManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                _logger.LogWarning($"Invalid Email {userDto.Email}");
                return new CustomResponseDto { IsSuccess = false, Message = "Invalid Email" };
            }
            if (user != null && !await _userManager.CheckPasswordAsync(user, userDto.Password))
            {
                _logger.LogWarning($"Invalid Password for {userDto.Email}");
                return new CustomResponseDto { IsSuccess = false, Message = "Invalid Password" };
            }
            var UserRole = await _roleManager.FindByNameAsync(userDto.Role);
            var roles = await _userManager.GetRolesAsync(user);
            var rle = roles.Where(a => a.Contains(userDto.Role)).FirstOrDefault();
            if (rle == null)
            {
                _logger.LogWarning($"Invalid Role for {userDto.Email}");
                return new CustomResponseDto { IsSuccess = false, Message = $"User {userDto.Email} don't has Role like {userDto.Role}" };
            }
            var obj = await GetUser(user, userDto.Role);
            return new CustomResponseDto
            {
                IsSuccess = true,
                Message = "Login successful",
                Obj = obj
            };
        }

        public async Task<CustomResponseDto> RegisterUser(UserDto userDto)
        {
            var user = _mapper.Map<UserPofile>(userDto);
            user.UserName = userDto.Email;
            var UserExist = await _userManager.FindByEmailAsync(userDto.Email);
            if (UserExist != null)
            {
                _logger.LogWarning($"A user with {userDto.Email} is already registered");
                return new CustomResponseDto { IsSuccess = false, Message = "A user with {userDto.Email} is already registered, Please try with other one" };
            }
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
                var users = _userManager.Users.ToList();
                var roles = _roleManager.Roles.ToList();
                var userRoles = new List<UsersWithRolesDto>();

                foreach (var user in users)
                {
                    var userRolesDto = new UsersWithRolesDto
                    {
                        UserId = user.Id,
                        UserName = $"{user.FirstName} {user.Lastname}",
                        Email = user.Email,
                        Roles = new List<RoleDto>()
                    };

                    foreach (var role in roles)
                    {
                        var isAssigned = await _userManager.IsInRoleAsync(user, role.Name);


                        userRolesDto.Roles.Add(new RoleDto
                        {
                            RoleId = role.Id,
                            RoleName = role.Name,
                            IsAssigned = isAssigned
                        });
                    }
                    userRoles.Add(userRolesDto);
                }
                return new CustomResponseDto { IsSuccess = true, Message = "Users retrieved successfully", Obj = userRoles };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users");
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<CustomResponseDto> GetUsersWithRole()
        {
            var users = _userManager.Users.ToList();

            return new CustomResponseDto { IsSuccess = true, Message = "Users retrieved successfully", Obj = await MapUsersToRoles(users) };
        }
        public async Task<CustomResponseDto> GetCustomerUsersWithRoles(string CustomerId)
        {
            try
            {
                var userRoles = new List<UserWithRoleDto>();
                if (!string.IsNullOrEmpty(CustomerId))
                {
                    var usersList = await _userManager.Users.Where(a => a.CustomerId == CustomerId).ToListAsync();
                    foreach (var user in usersList)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        userRoles.Add(new UserWithRoleDto
                        {
                            Id = user.Id,
                            UserName = user.FirstName + (string.IsNullOrEmpty(user.Lastname) ? "" : " " + user.Lastname),
                            Email = user.Email,
                            Role = roles.FirstOrDefault(),
                            CustomerId = user.CustomerId,
                            ParentId = user.ParentId
                        });
                    }

                }
                return new CustomResponseDto { IsSuccess = true, Message = "Users retrieved successfully", Obj = userRoles };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving users for customer {CustomerId}");
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
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Any())
                {

                    foreach (var role in roles)
                    {
                        userRoles.Add(new UserWithRoleDto
                        {
                            Id = user.Id,
                            UserName = $"{user.FirstName} {user.Lastname}",
                            Email = user.Email,
                            Role = role
                        });
                    }
                }
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
        private async Task<ResponseDto> GetUser(UserPofile user, string Role)
        {
            string ParentId = "0";
            string CustomerId = "0";

            string role = "";

            var roles = await _userManager.GetRolesAsync(user);
            var rle = roles.Where(a => a.Contains(Role)).FirstOrDefault();
            if (rle != null)
            {
                Role = roles.FirstOrDefault();
                if (rle.Contains("SuperAdmin"))
                {
                    ParentId = user.Id;
                }
                if (rle.Contains("Customer"))
                {
                    ParentId = user.ParentId;
                    CustomerId = user.Id;
                }
                if (rle.Contains("Vendor"))
                {
                    ParentId = user.ParentId;
                    CustomerId = user.CustomerId;
                }
                if (rle.Contains("Client"))
                {
                    ParentId = user.ParentId;
                    CustomerId = user.CustomerId;
                }
            }
            // var encodedTokenString = Base64UrlEncoder.Encode(tokenString);
            var token = await GenerateToken(user);

            var response = new ResponseDto
            {
                Email = user.Email,
                CreatedById = user.CreatedById,
                UserId = user.Id,
                CustomerId = CustomerId,
                SuperAdminId = ParentId,
                Role = rle,
                Token = token,
                UserName = user.FirstName + (string.IsNullOrEmpty(user.Lastname) ? "" : " " + user.Lastname),
            };
            return response;
        }

        public async Task<CustomResponseDto> AssignNewRole(UserRoleAssignmentDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.UserId);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {userDto.UserId} not found.");
                return new CustomResponseDto { IsSuccess = false, Message = "Invalid Email" };
            }
            // Get the current roles of the user
            var currentRoles = await _userManager.GetRolesAsync(user);

            // Remove existing roles
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            foreach (var roleId in userDto.RoleIds)
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    _logger.LogWarning($"User with Role {role} with UserId {userDto.UserId} not found.");
                    return new CustomResponseDto { IsSuccess = false, Message = "Role Not Exist" };
                }

                var userRole = new AspNetUserRole();




                if (userRole != null)
                {
                    userRole.RoleId = roleId;
                    userRole.UserId = userDto.UserId;
                    userRole.Discriminator = roleId;
                    userRole.CreateByID = userDto.CreateByID;
                    userRole.UpdatedByID = userDto.UpdatedByID;
                    userRole.UpdatedDate = userDto.UpdatedDate;
                    userRole.CreatedDate = userDto.CreatedDate;
                    userRole.AccessLevelID = userDto.AccessLevelID;
                    userRole.PersonStatusID = userDto.PersonStatusID;
                    // Update other fields as needed

                    await _context.UserRoles.AddAsync(userRole);
                    _context.SaveChanges();
                }
            }
            _logger.LogWarning($"Role Assigned Successfully");
            return new CustomResponseDto { IsSuccess = false, Message = "Role Assigned Successfully" };
        }
    }
}
