
using System.ComponentModel.DataAnnotations;

namespace Sample.WebApi.Models
{
    public class ProductCategory
    {
        [Key]
        
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [MaxLength]
        public string CategoryDescription { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
