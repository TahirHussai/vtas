using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    [Table("UserAssignedRegion")]
    public class UserAssignedRegion
    {
        [Key]
        public int ID { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedById { get; set; } = string.Empty;

        public string? UpdatedById { get; set; }

        public int AssignedRegionId { get; set; }
    }
}
