using Dapper;
using Microsoft.Extensions.Logging;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;
using System.Data;

namespace Sample.Services.Implementations
{
    public class PhoneService : IPhoneService
    {
        private readonly App_DapperContext _context;
        private readonly ILogger<PhoneService> _logger;

        public PhoneService(App_DapperContext context, ILogger<PhoneService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<PhoneDto>> GetPhonesByUserIdAsync(string userId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var phones = await connection.QueryAsync<PhoneDto>(
                        "sp_GetPhonesByUserId",
                        new { UserId = userId },
                        commandType: CommandType.StoredProcedure);

                    return phones.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving phones for UserID: {userId}");
                throw;
            }
        }

        public async Task<int> AddPhoneAsync(CreatePhoneDto phoneDto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PhoneNumber", phoneDto.PhoneNumber);
                parameters.Add("PhoneExt", phoneDto.PhoneExt);
                parameters.Add("PhoneTypeID", phoneDto.PhoneTypeID);
                parameters.Add("Active", phoneDto.Active);
                parameters.Add("UserId", phoneDto.UserId);
                parameters.Add("CreatedById", phoneDto.CreatedById);
                
                using (var connection = _context.CreateConnection())
                {
                    return await connection.ExecuteAsync(
                        "sp_CreatePhone", parameters,
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a phone.");
                throw;
            }
        }

        public async Task UpdatePhoneAsync(PhoneDto phoneDto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PhoneNumber", phoneDto.PhoneNumber);
                parameters.Add("PhoneExt", phoneDto.PhoneExt);
                parameters.Add("PhoneTypeID", phoneDto.PhoneTypeID);
                parameters.Add("Active", phoneDto.Active);
                parameters.Add("UserId", phoneDto.UserId);
                parameters.Add("PhoneID", phoneDto.PhoneID);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(
                        "sp_UpdatePhone",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the phone.");
                throw;
            }
        }

        public async Task<bool> DeletePhoneAsync(int id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var affectedRows = await connection.ExecuteAsync(
                        "sp_DeletePhone",
                        new { PhoneID = id },
                        commandType: CommandType.StoredProcedure);

                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the phone with ID: {id}");
                throw;
            }
        }
    }

}
