using Sample.DTOS;

namespace Sample.BlazorUI.Service
{
    public interface ILookUpRepository
    {
        public Task<List<PrefixDto>> GetPrefix();
        public Task<List<SufixDto>> GetSuffix();
        public  Task<List<EmailTypeDto>> GetEmailType();
        public Task<List<AddressTypeDto>> GetAddressType();
    }
}
