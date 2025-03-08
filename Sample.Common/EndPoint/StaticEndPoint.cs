namespace Sample.Common.EndPoint
{
    public class StaticEndPoint
    {
       

        //Api User Register/Login Endpoints
        #region Account Api
        public static string AuthRegisterEndpoint = $"api/Account/UserRegister";
        public static string AuthRegisterCustomerEndpoint = $"api/Account/RegisterCustomer";
        public static string AuthRegisterClientEndpoint = $"api/Account/RegisterClient";
        public static string AuthLoginEndpoint = $"api/Account/UserLogin";
        public static string GetUsersEndpoint = $"api/Account/AllUsersWithRole";
        public static string GetUserByIdEndpoint = $"api/Account/GetUserById/";
        public static string GetCustomerUsersEndpoint = $"api/Account/GetCustomerUsersWithRoles?CustomerId=";
        public static string GetClientUsersEndpoint = $"api/Account/GetClientUsersWithRoles?ClientId=";
        public static string GetVendorsUsersEndpoint = $"api/Account/GetVendorsUsersWithRoles?VendorId=";
        public static string UpdateUserRolesEndpoint = $"api/Account/assign-roles";
        public static string GetAllCustomersEndpoint = $"api/Account/GetAllCustomers";
        #endregion

        #region Lookups Api
        public static string GetAllAddressTypesEndpoint = "api/Lookup/address-types";
        public static string GetAllApplFileTypesEndpoint = "api/Lookup/appl-file-types";
        public static string GetAllEmailTypesEndpoint = "api/Lookup/email-types";
        public static string GetAllEntTypesEndpoint = "api/Lookup/ent-types";
        public static string GetAllFileTypesEndpoint = "api/Lookup/file-types";
        public static string GetAllFormFileTypesEndpoint = "api/Lookup/form-file-types";
        public static string GetAllJobTypesEndpoint = "api/Lookup/job-types";
        public static string GetAllPersonStatusesEndpoint = "api/Lookup/person-statuses";
        public static string GetAllPhoneTypesEndpoint = "api/Lookup/phone-types";
        public static string GetAllPrefixesEndpoint = "api/Lookup/prefixes";
        public static string GetAllShiftTypesEndpoint = "api/Lookup/shift-types";
        public static string GetAllSuffixEndpoint = "api/Lookup/suffix";
        public static string GetAllStatesEndpoint = "api/Lookup/states";
        public static string GetAllZipCodeEndpoint = "api/Lookup/zipCodes";
        #endregion
        public static string RegionCreateEndpoint = "api/Region/AddRegion";
        public static string RegionUpdateEndpoint = "api/Region/UpdateRegion";
        public static string RegionGetByIdEndPoint = "api/Region/GetRegionById/";
        public static string RegionGetEndPoint = "api/Region/GetRegions";
    }
}
