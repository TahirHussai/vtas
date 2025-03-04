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
    public class RegionRepository : IRegionRepository
    {
        private readonly App_BlazorDBContext _dbContext;
        public RegionRepository(App_BlazorDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CustomResponseDto> Add(RegionDTO dto)
        {
            CustomResponseDto response = new CustomResponseDto();
            try
            {
                LuRegion model = new LuRegion();
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;

                await _dbContext.LuRegions.AddAsync(model);
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

            var listdto = new List<RegionDTO>();
            var response = new CustomResponseDto();
            try
            {
                var list = _dbContext.LuRegions.ToList();
                if (list != null && list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        var obj = new RegionDTO();
                        obj.RegionID = item.RegionID;
                        obj.Abv = item.Abv;
                        obj.Desc = item.Desc;
                        listdto.Add(obj);
                    }
                    response.IsSuccess = true;
                    response.Message = "success";
                    response.Obj = listdto;
                }
                response.IsSuccess = false;
                response.Message = "No Record Found!";
                response.Obj = listdto;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.ToString();
                response.Obj = listdto;
            }
            return response;
        }

        public async Task<CustomResponseDto> GetById(int id)
        {
            var response = new CustomResponseDto();
            var dto = new RegionDTO();
            try
            {
                var model = await _dbContext.LuRegions.Where(a => a.RegionID == id).FirstOrDefaultAsync();
                if (model != null)
                {
                    dto.RegionID = model.RegionID;
                    dto.Abv = model.Abv;
                    dto.Desc = model.Desc;

                    response.IsSuccess = true;
                    response.Message = "success";
                    response.Obj = dto;
                }
                response.IsSuccess = false;
                response.Message = "No Record Found!";
                response.Obj = dto;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.ToString();
                response.Obj = dto;
            }
            return response;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<CustomResponseDto> Upate(RegionDTO dto)
        {
            CustomResponseDto response = new CustomResponseDto();
            try
            {
                var model = await _dbContext.LuRegions.FindAsync(dto.RegionID);
                if (model == null)
                    return response;


                model.RegionID = dto.RegionID;
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;
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
