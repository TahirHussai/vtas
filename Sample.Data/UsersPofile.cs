using Microsoft.AspNetCore.Identity;

namespace Sample.Data
{
    public class UserPofile: IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePicture { get; set; } 
        public string? UserPassword { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? ModifyById { get; set; }
        public string ParentId { get; set; }// ParentId is SuperAdminId
        public string CustomerId { get; set; }
        

    }
}
