using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DTOS
{
    public class OtherDetailsDto
    {
        [Required]
        public string Id { get; set; }
        public string UserId { get; set; }
        public int? ReferenceByID { get; set; }
        public int? SpouseId { get; set; }
        public bool FlagSubVendor { get; set; }
        public bool IsAllow { get; set; }
        public bool Flag_Virtual { get; set; }
        public bool BlockAutoQBR { get; set; }
        public bool BlockBGScreen { get; set; }
        public bool BlockDrugScreen { get; set; }
        public bool IsInSOLDB { get; set; }
        public bool SubmittalClientComp { get; set; }
        public string JobNotes { get; set; }
        public bool IsAllowDup { get; set; }
        public string Parent_VendorID { get; set; }
    }

}
