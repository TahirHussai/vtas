using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;

namespace Sample.Services.Implementations
{
    public class RegionService : IRegionService
    {
        private readonly App_BlazorDBContext _dbContext;
        private readonly IMapper _mapper;
        public RegionService(App_BlazorDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CustomResponseDto> Add(RegionDTO dto)
        {
            CustomResponseDto response = new CustomResponseDto();
            try
            {
                LuRegion model = new LuRegion();
                model.Abv = dto.Abv;
                model.Description = dto.Description;

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
                    listdto = _mapper.Map<List<RegionDTO>>(list);
                    response.IsSuccess = true;
                    response.Message = "success";
                    response.Obj = listdto;
                    return response;
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
                    dto= _mapper.Map<RegionDTO>(model);
                    response.IsSuccess = true;
                    response.Message = "success";
                    response.Obj = dto;
                    return response;
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
                model.Description = dto.Description;
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
        public async Task<CustomResponseDto> AddAssignedRegion(UserAssignedRegionDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();
            try
            {
                UserAssignedRegion model = new UserAssignedRegion
                {
                    CreatedDate = DateTime.Now,
                    UpdatedById = dto.UpdatedById,
                    CreatedById = dto.CreatedById,
                    UserId = dto.UserId,
                    AssignedRegionId = dto.AssignedRegionId,
                };
                await _dbContext.UserAssignedRegions.AddAsync(model);
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
        public async Task<CustomResponseDto> UpdateAssignedRegion(UserAssignedRegionDto dto)
        {
            CustomResponseDto response = new CustomResponseDto();
            try
            {
                var model = await _dbContext.UserAssignedRegions.FindAsync(dto.Id);
                if (model == null)
                    return response;

                model.UpdatedById = dto.UpdatedById;
                model.CreatedById = dto.CreatedById;
                model.UserId = dto.UserId;
                model.AssignedRegionId = dto.AssignedRegionId;
                model.UpdatedDate = DateTime.Now;
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
        public async Task<CustomResponseDto> GetAssignedRegionById(int Id)
        {
            var response = new CustomResponseDto();
            var dto = new UserAssignedRegionDto();
            try
            {
                var model = await _dbContext.UserAssignedRegions.Where(a => a.ID == Id).FirstOrDefaultAsync();
                if (model != null)
                {
                    dto = _mapper.Map<UserAssignedRegionDto>(model);
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

        public async Task<CustomResponseDto> GetAssignedRegionByUserId(string UserId)
        {
            var response = new CustomResponseDto();
            var dto = new UserAssignedRegionDto();
            try
            {
                var model = await _dbContext.UserAssignedRegions.Where(a => a.UserId == UserId).FirstOrDefaultAsync();
                if (model != null)
                {
                    dto = _mapper.Map<UserAssignedRegionDto>(model);
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
    }
}
