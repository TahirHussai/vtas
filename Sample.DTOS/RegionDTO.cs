using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DTOS
{
    public class RegionDTO
    {
        public int RegionID { get; set; }
        public bool IsChecked { get; set; } = false;
        public string Abv { get; set; }
        public string Description { get; set; }
    }
    public class RegionStatusDTO
    {
        public int RegionID { get; set; }
        public bool IsChecked { get; set; } = false;
    }
}
