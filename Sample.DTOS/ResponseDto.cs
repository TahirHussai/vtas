namespace Sample.DTOS
{
    public class ResponseDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string CustomerId { get; set; }
        public string SuperAdminId { get; set; }
        public string CreatedById { get; set; }

    }
    public class CustomResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Obj { get; set; }
    }


}
