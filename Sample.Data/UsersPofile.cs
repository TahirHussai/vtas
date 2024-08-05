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
        public string? MiddleName { get; set; }
        public int? SufixId { get; set; }
        public string? FamilyName { get; set; }
        public string? NickName { get; set; }
        public int? MailingAddressId { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? EmailWorkId { get; set; }
        public int? EmailPersonalId { get; set; }
        public int? EmergencyPersonId { get; set; }
        public int? SpouseId { get; set; }
        public string? Title { get; set; }
        public int? Crid { get; set; }
        public int? PrimaryPhoneId { get; set; }


    }
}
