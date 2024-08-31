using Microsoft.Extensions.Logging;
using Sample.Data;
using Sample.DTOS;
using Sample.Services.Interfaces;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Implementations
{
    public class LookupService : ILookupService
    {
       
        private readonly ILogger<LookupService> _logger;
      

        private readonly App_DapperContext _context;

      
        public LookupService(App_DapperContext context, ILogger<LookupService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CustomResponseDto> GetAllAddressTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUAddressType");
        }

        public async Task<CustomResponseDto> GetAllApplFileTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUApplFileType");
        }

        public async Task<CustomResponseDto> GetAllEmailTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUEmailType");
        }

        public async Task<CustomResponseDto> GetAllEntTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUEntType");
        }

        public async Task<CustomResponseDto> GetAllFileTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUFileType");
        }

        public async Task<CustomResponseDto> GetAllFormFileTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUFormFileType");
        }

        public async Task<CustomResponseDto> GetAllJobTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUJobType");
        }

        public async Task<CustomResponseDto> GetAllPersonStatusesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUPersonStatus");
        }

        public async Task<CustomResponseDto> GetAllPhoneTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUPhoneType");
        }

        public async Task<CustomResponseDto> GetAllPrefixesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUPrefix");
        }

        public async Task<CustomResponseDto> GetAllShiftTypesAsync()
        {
            return await GetLookupDataAsync("SELECT * FROM LUShiftType");
        }

        private async Task<CustomResponseDto> GetLookupDataAsync(string query)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var data = await connection.QueryAsync(query);
                    return new CustomResponseDto { IsSuccess = true, Obj = data, Message = "Data retrieved successfully." };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving lookup data");
                return new CustomResponseDto { IsSuccess = false, Message = "Error retrieving data.", Obj = null };
            }
        }
    }

}
