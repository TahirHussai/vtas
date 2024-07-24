namespace Sample.BlazorUI.EndPoint
{
    public class StaticEndPoint
    {
       

        //Api User Register/Login Endpoints
        #region Account Api
        public static string AuthRegisterEndpoint = $"api/Account/UserRegister";
        public static string AuthLoginEndpoint = $"api/Account/UserLogin";
        public static string GetUsersEndpoint = $"api/Account/AllUsersWithRole";
        public static string GetUserByIdEndpoint = $"api/Account/GetUserById?UserId=";
        public static string GetCustomerUsersEndpoint = $"api/Account/GetCustomerUsersWithRoles?CustomerId=";
        public static string GetClientUsersEndpoint = $"api/Account/GetClientUsersWithRoles?ClientId=";
        public static string GetVendorsUsersEndpoint = $"api/Account/GetVendorsUsersWithRoles?VendorId=";
        #endregion


       
    }
}
