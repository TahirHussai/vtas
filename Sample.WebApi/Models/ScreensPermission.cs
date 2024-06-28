namespace Sample.WebApi.Models
{
    public class ScreensPermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ScreenName { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanAccess { get; set; }
    }
}
