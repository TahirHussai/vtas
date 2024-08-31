using Dapper;
using Microsoft.Extensions.Logging;
using Sample.Data;
using Sample.DTOS;
using System;
using Sample.Services.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Implementations
{
    public class OtherDetailsService : IOtherDetailsService
    {
        private readonly ILogger<OtherDetailsService> _logger;
        private readonly App_DapperContext _context;
        public OtherDetailsService(App_DapperContext context, ILogger<OtherDetailsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CustomResponseDto> GetOtherDetailsByUserIdAsync(string userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                using (var connection = _context.CreateConnection())
                {

                    var otherDetails = await connection.QueryFirstOrDefaultAsync<OtherDetails>(
                        "sp_GetOtherDetailsByUserId",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    return new CustomResponseDto { IsSuccess = true, Message = "Other details retrieved successfully", Obj = otherDetails };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving other details for user ID: {UserId}", userId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> AddOrUpdateOtherDetailsAsync(OtherDetailsDto otherDetailsDto)
        {
            try
            {
                var id = string.IsNullOrEmpty(otherDetailsDto.Id) ? "0" : otherDetailsDto.Id;
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@UserId", otherDetailsDto.UserId);
                parameters.Add("@ReferenceByID", otherDetailsDto.ReferenceByID);
                parameters.Add("@SpouseId", otherDetailsDto.SpouseId);
                parameters.Add("@FlagSubVendor", otherDetailsDto.FlagSubVendor);
                parameters.Add("@IsAllow", otherDetailsDto.IsAllow);
                parameters.Add("@Flag_Virtual", otherDetailsDto.Flag_Virtual);
                parameters.Add("@BlockAutoQBR", otherDetailsDto.BlockAutoQBR);
                parameters.Add("@BlockBGScreen", otherDetailsDto.BlockBGScreen);
                parameters.Add("@BlockDrugScreen", otherDetailsDto.BlockDrugScreen);
                parameters.Add("@IsInSOLDB", otherDetailsDto.IsInSOLDB);
                parameters.Add("@SubmittalClientComp", otherDetailsDto.SubmittalClientComp);
                parameters.Add("@JobNotes", otherDetailsDto.JobNotes);
                parameters.Add("@IsAllowDup", otherDetailsDto.IsAllowDup);
                parameters.Add("@Parent_VendorID", otherDetailsDto.Parent_VendorID);

                using (var connection = _context.CreateConnection())
                {
                    var otherDetails = await connection.QueryFirstOrDefaultAsync<OtherDetails>(
                  "sp_AddOrUpdateOtherDetails",
                  parameters,
                  commandType: CommandType.StoredProcedure);


                    return new CustomResponseDto { IsSuccess = true, Message = !string.IsNullOrEmpty(otherDetailsDto.Id) ? "updated successfully" : "created successfully", Obj = otherDetails };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding/updating other details for ID: {Id}", otherDetailsDto.Id);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> DeleteOtherDetailsAsync(string id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                using (var connection = _context.CreateConnection())
                {
                    var otherDetails = await connection.QueryFirstOrDefaultAsync<OtherDetails>(
                  "sp_DeleteOtherDetails",
                  parameters,
                  commandType: CommandType.StoredProcedure);


                    return new CustomResponseDto { IsSuccess = true, Message = "Other details deleted successfully", Obj = otherDetails };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting other details for ID: {Id}", id);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

    }
}
