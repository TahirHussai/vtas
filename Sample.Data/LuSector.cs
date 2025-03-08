using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    [Table("LuSector")]
    public class LuSector
    {
        [Key]
        public int SectorID { get; set; }
        public string Abv { get; set; }
        public string Desc { get; set; }
    }
}
