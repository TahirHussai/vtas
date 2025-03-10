﻿using Sample.DTOS;

namespace Sample.BlazorUI.Repository.Interface
{
    public interface ILookUpRepository
    {
        public Task<List<PrefixDto>> GetPrefix();
        public Task<List<SufixDto>> GetSuffix();
        public Task<List<EmailTypeDto>> GetEmailType();
        public Task<List<AddressTypeDto>> GetAddressType();
        public Task<List<StateDto>> GetStates();
        public Task<List<ZipCodeDto>> GetZipCodes(string State);
    }
}
