using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Implementations
{
    public class EmailAddressService : IEmailAddressService
    {
        private readonly App_DapperContext _context;
        private readonly ILogger<EmailAddressService> _logger;

        public EmailAddressService(App_DapperContext dbConnection, ILogger<EmailAddressService> logger)
        {
            _context = dbConnection;
            _logger = logger;
        }

        public async Task<CustomResponseDto> GetEmailAddressByIdAsync(string emailId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmailId", emailId);
                using (var connection = _context.CreateConnection())
                {
                    var emailAddress = await connection.QueryFirstOrDefaultAsync<EmailAddress>(
                    "sp_GetEmailAddressById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    if (emailAddress == null)
                    {
                        return new CustomResponseDto { IsSuccess = false, Message = "Email address not found for the given ID" };
                    }

                    return new CustomResponseDto { IsSuccess = true, Message = "Email address retrieved successfully", Obj = emailAddress };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving email address for ID: {EmailId}", emailId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<List<EmailAddressDto>> GetEmailAddressByUserIdAsync(string UserId)
        {
            var obj = new List<EmailAddressDto>();
           
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", UserId);
                using (var connection = _context.CreateConnection())
                {
                    var emailAddress = await connection.QueryAsync<EmailAddressDto>(
                    "sp_GetEmailAddressByUserId",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    return (List<EmailAddressDto>)emailAddress;
                }
            
        }
        public async Task<CustomResponseDto> AddOrUpdateEmailAddressAsync(EmailAddressDto emailAddressDto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmailId", emailAddressDto.EmailId);
                parameters.Add("@Email", emailAddressDto.EmailAddress);
                parameters.Add("@EmailTypeId", emailAddressDto.EmailTypeId);
                parameters.Add("@IsActive", emailAddressDto.Active);
                parameters.Add("@CreatedById", emailAddressDto.CreatedById);
                parameters.Add("@UserId", emailAddressDto.UserId);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(
                    "sp_AddOrUpdateEmailAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    return new CustomResponseDto { IsSuccess = true, Message = !string.IsNullOrEmpty(emailAddressDto.EmailId.ToString()) ? "Email address updated successfully" : "Email address created successfully", Obj = result };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding/updating email address for ID: {EmailId}", emailAddressDto.EmailId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> DeleteEmailAddressAsync(string emailId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmailId", emailId);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(
                    "sp_DeleteEmailAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    return new CustomResponseDto { IsSuccess = true, Message = "Email address deleted successfully", Obj = result };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting email address for ID: {EmailId}", emailId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }
    }

}
