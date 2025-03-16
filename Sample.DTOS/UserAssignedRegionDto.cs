using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DTOS
{
    public class UserAssignedRegionDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedById { get; set; } = string.Empty;

        public string? UpdatedById { get; set; }

        public int AssignedRegionId { get; set; }
    }
}
