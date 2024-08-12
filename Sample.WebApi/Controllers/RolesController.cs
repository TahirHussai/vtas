using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.DTOS;



namespace Sample.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly App_BlazorDBContext _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager, IMapper mapper, App_BlazorDBContext app_BlazorDBContext)
        {
            _context = app_BlazorDBContext;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IEnumerable<RoleDTO>> GetIdentityRoles()
        {
            var roles = await _roleManager.Roles.ProjectTo<RoleDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return roles;
        }
    }
}
