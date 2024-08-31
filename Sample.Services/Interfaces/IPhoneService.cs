using Sample.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IPhoneService
    {
        Task<List<PhoneDto>> GetPhonesByUserIdAsync(string userId);
        Task<int> AddPhoneAsync(CreatePhoneDto phoneDto);
        Task UpdatePhoneAsync(PhoneDto phoneDto);
        Task<bool> DeletePhoneAsync(int id);
    }

}
