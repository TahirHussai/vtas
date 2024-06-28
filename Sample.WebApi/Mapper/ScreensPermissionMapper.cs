using AutoMapper;
using Sample.WebApi.DTO;
using Sample.WebApi.Models;

namespace Sample.WebApi.Mapper
{
    public class ScreensPermissionMapper :Profile
    {
        public ScreensPermissionMapper()
        {
            CreateMap<ScreensPermissionDTO, ScreensPermission>().ReverseMap();
        }
    }
}
