using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
        public int? SpouseId { get; set; }
        public string? Title { get; set; }
        public int? PrefixId { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        public int? PersonStatusID { get; set; }

        // Assuming you commented out PhoneId, AddressId, and ContactID intentionally, they are not included here.

        [MaxLength(250)]
        public string? OldVtasId { get; set; }

        [MaxLength(250)]
        public string? AltId { get; set; }

        [MaxLength(250)]
        public string? Crid { get; set; }

        [MaxLength(250)]
        public string? FaxID { get; set; }

        [MaxLength(250)]
        public string? OldId { get; set; }

        [MaxLength(100)]
        public string? IndustryID { get; set; }

        [MaxLength(100)]
        public string? LOB_ID { get; set; }



    }
}
