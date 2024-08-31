using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sample.Data
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public int? CountyId { get; set; }
        public string? CreatedById { get; set; }
        public DateTime CreateDate { get; set; }
        public int AddressTypeId { get; set; }
        public bool Active { get; set; }
    }

}
