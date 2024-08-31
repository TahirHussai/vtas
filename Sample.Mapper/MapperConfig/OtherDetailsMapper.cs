using AutoMapper;
using Sample.Data;
using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Mapper.MapperConfig
{
    public class OtherDetailsMapper:Profile
    {
        public OtherDetailsMapper()
        {
            CreateMap<OtherDetails, OtherDetailsDto>();
            CreateMap<OtherDetailsDto, OtherDetails>();
        }
    }
}
