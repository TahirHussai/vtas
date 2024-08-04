﻿using AutoMapper;
using Sample.Data;
using Sample.DTOS;

namespace Sample.Mapper.MaperConfig
{
    public class UserPofileMapper:Profile
    {
        public UserPofileMapper() {
            CreateMap<UserDto, UserPofile>().ReverseMap();
        }
    }
}