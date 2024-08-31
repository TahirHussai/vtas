using Dapper;
using Microsoft.Extensions.Logging;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Implementations
{
    public class EmailAddressService : IEmailAddressService
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<EmailAddressService> _logger;

        public EmailAddressService(IDbConnection dbConnection, ILogger<EmailAddressService> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<CustomResponseDto> GetEmailAddressByIdAsync(int emailId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmailId", emailId);

                var emailAddress = await _dbConnection.QueryFirstOrDefaultAsync<EmailAddress>(
                    "sp_GetEmailAddressById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (emailAddress == null)
                {
                    return new CustomResponseDto { IsSuccess = false, Message = "Email address not found for the given ID" };
                }

                return new CustomResponseDto { IsSuccess = true, Message = "Email address retrieved successfully", Obj = emailAddress };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving email address for ID: {EmailId}", emailId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> AddOrUpdateEmailAddressAsync(EmailAddressDto emailAddressDto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmailId", emailAddressDto.EmailId);
                parameters.Add("@Email", emailAddressDto.Email);
                parameters.Add("@EmailTypeId", emailAddressDto.EmailTypeId);
                parameters.Add("@IsActive", emailAddressDto.Active);
                parameters.Add("@CreatedById", emailAddressDto.CreatedById);

                var result = await _dbConnection.ExecuteAsync(
                    "sp_AddOrUpdateEmailAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return new CustomResponseDto { IsSuccess = true, Message = !string.IsNullOrEmpty(emailAddressDto.EmailId.ToString()) ? "Email address updated successfully" : "Email address created successfully", Obj = result };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding/updating email address for ID: {EmailId}", emailAddressDto.EmailId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> DeleteEmailAddressAsync(int emailId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmailId", emailId);

                var result = await _dbConnection.ExecuteAsync(
                    "sp_DeleteEmailAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return new CustomResponseDto { IsSuccess = true, Message = "Email address deleted successfully", Obj = result };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting email address for ID: {EmailId}", emailId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }
    }

}
