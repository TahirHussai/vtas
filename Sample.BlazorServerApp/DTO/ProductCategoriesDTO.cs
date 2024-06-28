using System.ComponentModel.DataAnnotations;

namespace Sample.BlazorServerAPP.DTO
{
    public class ProductCategoriesDTO
    {
        
         public int CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [MaxLength]
        public string CategoryDescription { get; set; }


        public DateTime CreationDate { get; set; }
    }
    public class ProductCategoryCountDTO
    {
        public string CategoryName { get; set; }

        public int TotalItem { get; set; }
    }
}
