using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DTOS
{
    public class EmailAddressDto
    {
        public int EmailId { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(100, ErrorMessage = "Email address cannot exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email type ID is required")]
        public int? EmailTypeId { get; set; }

        public bool Active { get; set; } = false;

        public string? CreatedById { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }

}
