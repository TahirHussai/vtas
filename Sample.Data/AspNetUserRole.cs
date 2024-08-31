using Microsoft.AspNetCore.Identity;


namespace Sample.Data
{
    public  class AspNetUserRole : IdentityUserRole<string>
    {
        public string? CreateByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedByID { get; set; }
        public string Discriminator { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        //public int? AccessLevelID { get; set; }
        public int? PersonStatusID { get; set; }
       
    }
}
