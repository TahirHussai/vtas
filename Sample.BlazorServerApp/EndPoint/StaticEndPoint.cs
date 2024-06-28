namespace Sample.BlazorServerAPP.EndPoint
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


        //Api Product Endpoints
        #region Product Api

        public static string GetProductsEndpoint = $"{BaseUrl}api/Products/GetProducts/";
        public static string GetSingleProductsEndpoint = $"{BaseUrl}api/Products/";
        public static string AddProductEndpoint = $"{BaseUrl}api/Products/AddProduct";
        public static string EditProductEndpoint = $"{BaseUrl}api/Products/";
        public static string DeleteProductEndpoint = $"{BaseUrl}api/Products/";
        public static string GetProductCountEndpoint = $"{BaseUrl}api/Products/GetCategoryCount";
        #endregion

        //Api Product Category Endpoints
        #region Product Category Api
        public static string GetProductCategoriesEndpoint = $"{BaseUrl}api/ProductCategories/GetProductsCategories/";
        public static string GetSingleProductCategoriesEndpoint = $"{BaseUrl}api/ProductCategories/";
        public static string AddProductCategoriesEndpoint = $"{BaseUrl}api/ProductCategories/AddProductCategories";
        public static string EditProductCategoriesEndpoint = $"{BaseUrl}api/ProductCategories/";
        public static string DeleteProductCategoriesEndpoint = $"{BaseUrl}api/ProductCategories/";
        #endregion


        //Redirect Url
        public static string ExternalRedirectEndpoint = $"{RedirectBaseUrl}ExternalLoginCallback";

        //External Logins
        #region ExternalLogins
        public static string AuthExternalGoogleLoginEndpoint = $"{BaseUrl}api/Account/google-login";
        public static string AuthExternalFacebookLoginEndpoint = $"{BaseUrl}api/Account/facebook-login";
        public static string AuthExternalLinedIdLoginEndpoint = $"{BaseUrl}api/Account/signin-linkedin";
        public static string AuthExternalGithubLoginEndpoint = $"{BaseUrl}api/Account/signin-github";
        public static string AuthExternalYahooLoginEndpoint = $"{BaseUrl}api/Account/signin-yahoo";
        public static string AuthExternalMicrosoftLoginEndpoint = $"{BaseUrl}api/Account/microsoft-login";
        #endregion

        //Roles
        public static string RolesEndpoint = $"{BaseUrl}api/Roles/GetIdentityRoles";


        //Permissions
        #region Permissions
        public static string GetPermissionsEndpoint = $"{BaseUrl}api/ScreensPermissions/GetAllPermissions";
        public static string GetPermissionsByRoleIdEndpoint = $"{BaseUrl}api/ScreensPermissions/GetPermissionsForRoleAsync";
        public static string GetPermissionsByIdEndpoint = $"{BaseUrl}api/ScreensPermissions/GetPermissionsById";
        public static string SavePermissionsEndpoint = $"{BaseUrl}api/ScreensPermissions/SavePermissions";
        public static string UpdatePermissionsEndpoint = $"{BaseUrl}api/ScreensPermissions/UpdatePermissions";
        #endregion
    }
}
