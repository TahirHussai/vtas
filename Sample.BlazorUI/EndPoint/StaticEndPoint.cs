namespace Sample.BlazorUI.EndPoint
{
    public class StaticEndPoint
    {
       

        //Api User Register/Login Endpoints
        #region Account Api
        public static string AuthRegisterEndpoint = "$api/Account/UserRegister";
        public static string AuthLoginEndpoint = $"api/Account/UserLogin";
        public static string GetUsersEndpoint = $"api/Account/AllUsersWithRoles";
        #endregion


       
    }
}
