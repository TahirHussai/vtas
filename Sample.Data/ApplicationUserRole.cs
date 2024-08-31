using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedByID { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int PersonStatusID { get; set; }
        public string Discriminator { get; set; }
    }

}
