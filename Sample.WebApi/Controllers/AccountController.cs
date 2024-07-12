using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sample.DTOS;
using Sample.WebApi;
using Sample.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Sample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserPofile> userManager;
        private readonly SignInManager<UserPofile> signInManager;
        private readonly IMapper mapper;
        private readonly ILogger<AccountController> logger;
        private readonly IConfiguration configuration;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;


        public AccountController(JwtSecurityTokenHandler jwtSecurityTokenHandler, IConfiguration configuration, ILogger<AccountController> logger, IMapper mapper, UserManager<UserPofile> userManager, SignInManager<UserPofile> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.logger = logger;
            this.configuration = configuration;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }
        [HttpPost]
        [Route("UserLogin")]
        public async Task<ActionResult<ResponseDto>> Login(LoginDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }
            try
            {
                logger.LogInformation($"Attempt User Logn via {userDto.Email}");
                return await LoginUser(userDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong in  the {nameof(Login)} with user {userDto.Email}");
                return Problem(ex.ToString());
            }
        }
        [HttpPost]
        [Route("UserRegister")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }
            try
            {
                return await RegisterUser(userDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong in  the {nameof(Register)} with user {userDto.Email}");

            }
            return Ok();
        }

        [HttpGet("GetUserById")]
        //[Authorize(Roles = "SuperAdmin")] // Optional: Require Admin role to access this endpoint
        public async Task<IActionResult> GetUserById(string UserId)
        {
            var user = new UserPofile();

            user = await userManager.FindByIdAsync(UserId);
            var response =await GetUser(user);

            return Ok(response);
        }
        [HttpGet("AllUsersWithRoles")]
        //[Authorize(Roles = "SuperAdmin")] // Optional: Require Admin role to access this endpoint
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            var usersList = userManager.Users.ToList();
            var userRoles = new List<UserWithRolesDto>();

            foreach (var user in usersList)
            {
                var roles = await userManager.GetRolesAsync(user);
                userRoles.Add(new UserWithRolesDto
                {
                    Id = user.Id,
                    UserName = user.FirstName + (string.IsNullOrEmpty(user.Lastname) ? "" : " " + user.Lastname),
                    Email = user.Email,
                    Role = roles.FirstOrDefault(),
                    CustomerId = user.CustomerId,
                    ParentId = user.ParentId
                });
            }

            return Ok(userRoles);
        }

        [HttpGet("GetCustomerUsersWithRoles")]
        //[Authorize(Roles = "Customer")] // Optional: Require Customer role to access this endpoint
        public async Task<IActionResult> GetCustomerUsersWithRoles(string CustomerId)
        {
            var userRoles = new List<UserWithRolesDto>();
            if (!string.IsNullOrEmpty(CustomerId))
            {
                var usersList = await userManager.Users.Where(a => a.CustomerId == CustomerId).ToListAsync();
                foreach (var user in usersList)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    userRoles.Add(new UserWithRolesDto
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
            return Ok(userRoles);
        }

        [HttpGet("GetClientUsersWithRoles")]
        //[Authorize(Roles = "Client")] // Optional: Require Client role to access this endpoint
        public async Task<IActionResult> GetClientUsersWithRoles(string ClientId, string CustomerId)
        {
            var userRoles = new List<UserWithRolesDto>();
            if (!string.IsNullOrEmpty(ClientId))
            {
                var usersList = await userManager.Users.Where(a => a.CustomerId == CustomerId && a.CreatedById== ClientId).ToListAsync();
                foreach (var user in usersList)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    userRoles.Add(new UserWithRolesDto
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
            return Ok(userRoles);
        }
        [HttpGet("GetVendorsUsersWithRoles")]
        //[Authorize(Roles = "Vendor")] // Optional: Require Vendor role to access this endpoint
        public async Task<IActionResult> GetVendorsUsersWithRoles(string VendorId, string CustomerId)
        {
            var UserRoles = new UserWithRolesDto();
            if (!string.IsNullOrEmpty(VendorId))
            {
                var user = userManager.Users.FirstOrDefault(a => a.CreatedById == VendorId  && a.CustomerId == CustomerId);
                if (user != null)
                {

                    var roles = await userManager.GetRolesAsync(user);

                    UserRoles.Id = user.Id;
                    UserRoles.UserName = user.FirstName + (string.IsNullOrEmpty(user.Lastname) ? "" : " " + user.Lastname);
                    UserRoles.Email = user.Email;
                    UserRoles.Role = roles.FirstOrDefault();
                    UserRoles.CustomerId = user.CustomerId;
                    UserRoles.ParentId = user.ParentId;
                }

            }
            return Ok(UserRoles);
        }

        [HttpGet("GetRecruiterUsersWithRoles")]
        //[Authorize(Roles = "Vendor")] // Optional: Require Vendor role to access this endpoint
        public async Task<IActionResult> GetRecruiterUsersWithRoles(string RecruiterId, string CustomerId)
        {
            var UserRoles = new UserWithRolesDto();
            if (!string.IsNullOrEmpty(RecruiterId))
            {
                var user = userManager.Users.FirstOrDefault(a => a.CreatedById == RecruiterId && a.Id == RecruiterId && a.CustomerId == CustomerId);
                if (user != null)
                {

                    var roles = await userManager.GetRolesAsync(user);

                    UserRoles.Id = user.Id;
                    UserRoles.UserName = user.FirstName + (string.IsNullOrEmpty(user.Lastname) ? "" : " " + user.Lastname);
                    UserRoles.Email = user.Email;
                    UserRoles.Role = roles.FirstOrDefault();
                    UserRoles.CustomerId = user.CustomerId;
                    UserRoles.ParentId = user.ParentId;
                }

            }
            return Ok(UserRoles);
        }
        private async Task<IActionResult> RegisterUser(UserDto userDto)
        {

            logger.LogInformation($"Attempt User Register via {userDto.Email}");
            var user = mapper.Map<UserPofile>(userDto);
            user.UserName = userDto.Email;
            user.ProfilePicture = " ";
            user.UserPassword = userDto.Password;
            user.CreatedById = userDto.CreatedById;
            user.ParentId = userDto.SuperAdminId;
            user.CustomerId = userDto.CustomerId;
            user.CreatedDate = DateTime.Now;
            var suceess = await userManager.CreateAsync(user, userDto.Password);
            if (suceess.Succeeded == false)
            {
                foreach (var item in suceess.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                    return BadRequest(ModelState);
                }
            }
            await userManager.AddToRoleAsync(user, userDto.RoleName);
            return Ok();
        }
        private async Task<ActionResult<ResponseDto>> LoginUser(LoginDTO userDto)
        {
            ResponseDto response = new ResponseDto();
            try
            {

            
            var user = await userManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                logger.LogError($"Something went wrong with the {userDto.Email}");
                return Unauthorized(userDto);
            }

            var validatePassword = await userManager.CheckPasswordAsync(user, userDto.Password);
            if (validatePassword == false)
            {
                return Unauthorized(userDto);
            }

            var token = await GenerateToken(user);

            await userManager.UpdateAsync(user);
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var tokenString = tokenHandler.WriteToken(token);

             response = await GetUser(user);
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        private async Task<ResponseDto> GetUser(UserPofile user)
        {
            string ParentId = "0";
            string CustomerId = "0";

            string Role = "";

            var roles = await userManager.GetRolesAsync(user);
            if (roles.Any())
            {
                Role = roles.FirstOrDefault();
                if (Role.Contains("SuperAdmin"))
                {
                    ParentId = user.Id;
                }
                if (Role.Contains("Customer"))
                {
                    ParentId = user.ParentId;
                    CustomerId = user.Id;
                }
                if (Role.Contains("Vendor"))
                {
                    ParentId = user.ParentId;
                    CustomerId = user.CustomerId;
                }
                if (Role.Contains("Client"))
                {
                    ParentId = user.ParentId;
                    CustomerId = user.CustomerId;
                }
            }
            // var encodedTokenString = Base64UrlEncoder.Encode(tokenString);

            var response = new ResponseDto
            {
                Email = user.Email,
                CreatedById = user.CreatedById,
                UserId = user.Id,
                CustomerId = CustomerId,
                SuperAdminId = ParentId,
                Role = Role,
                UserName = user.FirstName + (string.IsNullOrEmpty(user.Lastname) ? "" : " " + user.Lastname),
            };
            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(UserPofile user)
        {
            try
            {


                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:IssuerSigningKey"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                //        var userClaims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, user.Email)
                //};
                //        var roles = await userManager.GetRolesAsync(user);
                //        foreach (var role in roles)
                //        {
                //            userClaims.Add(new Claim(ClaimTypes.Role, role));
                //        }

                string ParentId = "0";
                string CustomerId = "0";
                string Role = "";

                var roles = await userManager.GetRolesAsync(user);
                if (roles.Any())
                {
                    Role = roles.FirstOrDefault();
                    if (Role.Contains("SuperAdmin"))
                    {
                        ParentId = user.Id;
                    }
                    if (Role.Contains("Customer"))
                    {
                        ParentId = user.ParentId;
                        CustomerId = user.Id;
                    }
                    if (Role.Contains("Vendor"))
                    {
                        ParentId = user.ParentId;
                        CustomerId = user.CustomerId;
                    }
                    if (Role.Contains("Client"))
                    {
                        ParentId = user.ParentId;
                        CustomerId = user.CustomerId;
                    }
                }
                var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

                var userClaims = await userManager.GetClaimsAsync(user);

                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim(ClaimTypes.Name, user.FirstName+" "+ user.Lastname),
                 new Claim("ProfileImage", user.ProfilePicture),
                 new Claim("LoginUserId", user.Id),
                 new Claim("ParentId", user.Id),
                 new Claim("CustomerId", CustomerId),
            }
               .Union(userClaims)
               .Union(roleClaims);
                var duration = DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["jWTSetting:Duration"]));
                var token = new JwtSecurityToken(
                    issuer: configuration["jWTSetting:Issuer"],
                    audience: configuration["jWTSetting:Audience"],
                    claims: claims,
                    expires: duration,
                    signingCredentials: credentials
                );
                return token;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jWTSetting:IssuerSigningKey"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }
    }
}
