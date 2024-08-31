using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DTOS
{
    public class AddressDto
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Address1 is required")]
        [MaxLength(50, ErrorMessage = "Address1 cannot exceed 50 characters")]
        public string Address1 { get; set; }

        [MaxLength(50, ErrorMessage = "Address2 cannot exceed 50 characters")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string City { get; set; }

        public int? StateId { get; set; }

        [MaxLength(15, ErrorMessage = "PostalCode cannot exceed 15 characters")]
        public string PostalCode { get; set; }

        public int? CountryId { get; set; }
        public int? CountyId { get; set; }

        public string? CreatedById { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int AddressTypeId { get; set; } = 0;

        public bool Active { get; set; } = false;
    }

}
