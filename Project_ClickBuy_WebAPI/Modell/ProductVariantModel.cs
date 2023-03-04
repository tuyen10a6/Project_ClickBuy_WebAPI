using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductVariantModel
    {
        public int VARRIANTID { get; set; }
        public string VARRIANNAME { get; set; }
        public int ProductID { get; set; }
        public string COLOR { get; set; }   
        public string Capacity { get;set; }
        public int PRICE { get; set; }
        public string ImageVariant { get; set; }
    }
}
