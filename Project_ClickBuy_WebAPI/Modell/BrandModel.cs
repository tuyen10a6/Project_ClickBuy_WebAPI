using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BrandModel
    {
      public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Country { get; set; }
        public string? Website { get; set; }
        public string? ContactPerson { get; set; }   
        public string? ContactPhone { get; set; } 
        public int? CategoryID { get; set;}
        public string? CategoryName { get; set; }
    }
}
