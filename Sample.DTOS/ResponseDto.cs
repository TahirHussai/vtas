namespace Sample.DTOS
{
    public class ResponseDto
    {
        public string Email { get; set; }

        public string TokenString { get; set; }
        public string UserId { get; set; }

    }
    public class ExterLogin
    {
        public Object HandlerType { get; set; }
        public string loginName { get; set; }
        public string RedirectUrl { get; set; }
    }

}
