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
}
