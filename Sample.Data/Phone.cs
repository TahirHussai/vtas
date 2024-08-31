using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class Phone
    {
        public int PhoneID { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExt { get; set; }
        public int? PhoneTypeID { get; set; }
        public bool? Active { get; set; }
        public int? CreatedByPersonID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
    }


}
