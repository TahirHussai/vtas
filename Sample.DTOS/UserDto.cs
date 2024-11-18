using System.ComponentModel.DataAnnotations;

namespace Sample.DTOS
{
    public class UserDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "CreatedBy Id is required.")]
        public string CreatedById { get; set; }
        [Required(ErrorMessage = "Role Name is required.")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Customer Id is required.")]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "SuperAdmin Id is required.")]
        public string SuperAdminId { get; set; }
    }
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "CreatedBy Id is required.")]
        public string CreatedById { get; set; }
        [Required(ErrorMessage = "Role Name is required.")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Customer Id is required.")]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "SuperAdmin Id is required.")]
        public string SuperAdminId { get; set; }
        [Required(ErrorMessage = "UserId Id is required.")]
        public string UserId { get; set; }
    }

    public class UserCustomerDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string? DisplayName { get; set; }
    [Required(ErrorMessage = "Email is required.")]
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "CreatedBy Id is required.")]
        public string? CreatedById { get; set; }
        [Required(ErrorMessage = "Role Name is required.")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Customer Id is required.")]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "SuperAdmin Id is required.")]
        public string SuperAdminId { get; set; }
        public int? PrefixId { get; set; }
        public int? SuffixId { get; set; }
        public int? ExtId { get; set; }
        public string? Fax { get; set; }
        public string? Phone { get; set; }
        //public string? MailingAddress { get; set; }
        //public string? Address2 { get; set; }
        //public string? ZipCode { get; set; }
        //public string? City { get; set; }
        //public string? State { get; set; }
        //public int? CountryId { get; set; }
        //public int? AddressTypeId { get; set; }
        //public int? EmailTypeId { get; set; }
        public AddressDto AddressDto { get; set; } = new AddressDto(); // Initialize here
        public EmailAddressDto EmailAddressDto { get; set; } = new EmailAddressDto(); // Initialize here
    }
}
