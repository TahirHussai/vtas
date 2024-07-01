namespace Sample.BlazorUI.DTO
{
    public class ResponseDto
    {
        public string Email { get; set; }
       
        public string TokenString { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        

    }
    public class ExterLogin
    {
        public Object HandlerType { get; set; }
        public string loginName { get; set; }
        public string RedirectUrl { get; set; }
    }
}