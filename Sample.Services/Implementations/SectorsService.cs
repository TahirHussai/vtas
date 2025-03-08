using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Implementations
{
    public class SectorsService : ISectorsServices
    {
        private readonly App_BlazorDBContext _dbContext;
        private readonly IMapper _mapper;
        public SectorsService(App_BlazorDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CustomResponseDto> Add(SectorDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();
            try
            {
                LuSector model = new LuSector();
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;

               await _dbContext.LuSectors.AddAsync(model);
                Save();
                response.IsSuccess = true;
                response.Message = "success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        public async Task<CustomResponseDto> Get()
        {
           var response = new CustomResponseDto();

            var list = await _dbContext.LuSectors.ToListAsync();
            if (list != null && list.Count() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Success";
                response.Obj = _mapper.Map<List<SectorDto>>(list);
            }

            return response;
        }

        public async Task<CustomResponseDto> GetById(int id)
        {
            var response = new CustomResponseDto();
            SectorDto dto = new SectorDto();
            var model = await _dbContext.LuSectors.Where(a => a.SectorID == id).FirstOrDefaultAsync();
            if (model != null)
            {
                response.IsSuccess = true;
                response.Message = "Success";
                response.Obj = _mapper.Map<SectorDto>(model);
            }
            return response;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<CustomResponseDto> Upate(SectorDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();
            try
            {
                LuSector model = new LuSector();
                model.SectorID = dto.SectorID;
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;
                _dbContext.LuSectors.Update(model);
                Save();
                response.IsSuccess = true;
                response.Message = "success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }
    }
}
