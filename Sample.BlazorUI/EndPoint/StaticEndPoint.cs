namespace Sample.BlazorUI.EndPoint
{
    public class StaticEndPoint
    {
        public static string BaseUrl = "https://localhost:7182/";
        public static string RedirectBaseUrl = "https://localhost:7071/";

        //Api User Register/Login Endpoints
        #region Account Api
        public static string AuthRegisterEndpoint = $"{BaseUrl}api/Account/UserRegister";
        public static string AuthLoginEndpoint = $"{BaseUrl}api/Account/UserLogin";
        public static string AuthRefreshEndpoint = $"{BaseUrl}api/Account/refresh-token";
        #endregion


       
    }
}
