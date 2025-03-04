using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    [Table("LuRegion")]
    public class LuRegion
    {
        [Key]
        public int RegionID { get; set; }
        public string Abv { get; set; }
        public string Desc { get; set; }
    }

}
