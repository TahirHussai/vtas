using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DTOS
{

    public class PhoneDto
    {
        public int PhoneID { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExt { get; set; }
        public int? PhoneTypeID { get; set; }
        public bool? Active { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
    }
    public class CreatePhoneDto
    {
        public string PhoneNumber { get; set; }
        public string PhoneExt { get; set; }
        public int? PhoneTypeID { get; set; }
        public bool? Active { get; set; }
        public string CreatedById { get; set; }
        public string UserId { get; set; }
    }
    public class FaxDto
    {
        public int PhoneID { get; set; }
        public string Fax { get; set; }
        public string Ext { get; set; }
        public int? TypeID { get; set; }
        public bool? Active { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
    }
}
