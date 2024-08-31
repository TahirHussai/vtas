using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    [Table("EmailAddress")]
    public class EmailAddress
    {
        [Key]
        public int EmailId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public int? EmailTypeId { get; set; }
        public bool Active { get; set; }
        public string? CreatedById { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
