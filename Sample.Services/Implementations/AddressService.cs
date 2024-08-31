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

namespace Sample.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<AddressService> _logger;

        public AddressService(IDbConnection dbConnection, ILogger<AddressService> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<CustomResponseDto> GetAddressByIdAsync(int addressId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AddressId", addressId);

                var address = await _dbConnection.QueryFirstOrDefaultAsync<Address>(
                    "sp_GetAddressById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return new CustomResponseDto { IsSuccess = true, Message = "Address retrieved successfully", Obj = address };
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
                parameters.Add("@StateId", addressDto.StateId);
                parameters.Add("@PostalCode", addressDto.PostalCode);
                parameters.Add("@CountryId", addressDto.CountryId);
                parameters.Add("@CountyId", addressDto.CountyId);
                parameters.Add("@CreatedById", addressDto.CreatedById);
                parameters.Add("@AddressTypeId", addressDto.AddressTypeId);
                parameters.Add("@Active", addressDto.Active);

                var result = await _dbConnection.ExecuteAsync(
                    "sp_AddOrUpdateAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return new CustomResponseDto { IsSuccess = true, Message = !string.IsNullOrEmpty(addressDto.AddressId.ToString()) ? "Address updated successfully" : "Address created successfully", Obj = result };
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

                var result = await _dbConnection.ExecuteAsync(
                    "sp_DeleteAddress",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return new CustomResponseDto { IsSuccess = true, Message = "Address deleted successfully", Obj = result };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting address for ID: {AddressId}", addressId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<CustomResponseDto> GetAddressByUserIdAsync(int userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);

                var address = await _dbConnection.QueryFirstOrDefaultAsync<Address>(
                    "sp_GetAddressByUserId",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (address == null)
                {
                    return new CustomResponseDto { IsSuccess = false, Message = "Address not found for the given UserId" };
                }

                return new CustomResponseDto { IsSuccess = true, Message = "Address retrieved successfully", Obj = address };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving address for UserId: {UserId}", userId);
                return new CustomResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

    }

}
