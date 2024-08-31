using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DTOS
{
    public class LUAddressTypeDto
    {
        public int AddressTypeID { get; set; }
        public string AddressTypeVAL { get; set; }
    }

    public class LUApplFileTypeDto
    {
        public int FTId { get; set; }
        public string FTName { get; set; }
    }
    public class CustomLookUpDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    // Repeat similar DTOs for each table
    public class PrefixDto
    {
        public int PrefixID { get; set; }
        public string PrefixVal { get; set; }
    }
    public class SufixDto
    {
        public int SuffixID { get; set; }
        public string SuffixVAL { get; set; }
    }
    public class AddressTypeDto
    {
        public int AddressTypeID { get; set; }
        public string AddressTypeVAL { get; set; }
    }
    public class EmailTypeDto
    {
        public int EMAILTYPEID { get; set; }
        public string EMAILTYPEVAL { get; set; }
    }
}
