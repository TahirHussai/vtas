using Dapper;
using Microsoft.Extensions.Logging;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sample.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly App_DapperContext _context;
        private readonly ILogger<AddressService> _logger;

        public AddressService(App_DapperContext context, ILogger<AddressService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CustomResponseDto> GetAddressByIdAsync(int addressId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AddressId", addressId);
                using (var connection = _context.CreateConnection())
                {
                    var address = await connection.QueryFirstOrDefaultAsync<Address>(
                    "sp_GetAddressById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    return new CustomResponseDto { IsSuccess = true, Message = "Address retrieved successfully", Obj = address };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving address for ID: {AddressId}", addressId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> AddOrUpdateAddressAsync(AddressDto addressDto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AddressId", addressDto.AddressId);
                parameters.Add("@Address1", addressDto.Address1);
                parameters.Add("@Address2", addressDto.Address2);
                parameters.Add("@City", addressDto.City);
                parameters.Add("@State", addressDto.State);
                parameters.Add("@PostalCode", addressDto.PostalCode);
                parameters.Add("@CountryId", addressDto.CountryId);
                parameters.Add("@CreatedById", addressDto.CreatedById);
                parameters.Add("@AddressTypeId", addressDto.AddressTypeId);
                parameters.Add("@Active", true);
                parameters.Add("@UserId", addressDto.UserId);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(
                    "sp_AddOrUpdateAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    return new CustomResponseDto { IsSuccess = true, Message = !string.IsNullOrEmpty(addressDto.AddressId.ToString()) ? "Address updated successfully" : "Address created successfully", Obj = result };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding/updating address for ID: {AddressId}", addressDto.AddressId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomResponseDto> DeleteAddressAsync(int addressId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AddressId", addressId);
                using (var connection = _context.CreateConnection())
                {

                    var result = await connection.ExecuteAsync(
                    "sp_DeleteAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                    return new CustomResponseDto { IsSuccess = true, Message = "Address deleted successfully", Obj = result };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting address for ID: {AddressId}", addressId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<AddressDto> GetAddressByUserIdAsync(string userId)
        {
            var address = new AddressDto();

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            using (var connection = _context.CreateConnection())
            {
                 address = await connection.QueryFirstOrDefaultAsync<AddressDto>(
                "sp_GetAddressByUserId",
                parameters,
                commandType: CommandType.StoredProcedure);
                if (address==null)
                {
                    address = new AddressDto();
                    address.Address1 = string.Empty;
                        address.Address2 = string.Empty;
                        address.City = string.Empty;
                        address.PostalCode = string.Empty;
                        address.State = string.Empty;
                }
                return address;


            }

        }


    }

}
