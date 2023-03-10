using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SanPhamModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateCreated { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public int? PRICE { get; set; }
        public List<ProductVariants> Variants { get; set; } = new List<ProductVariants>();
        public List<Specification> Attributes { get; set; } = new List<Specification>();
    }
    public class ProductVariants
    {
        public int VARRIANTID { get; set; }
        public string VARRIANNAME { get; set; }
        public int ProductID { get; set; }
        public string Color { get; set; }
        public string Capacity { get; set; }
        public int Price { get; set; }
        public string ImageVariant { get; set; }
             
    }

    public class Specification
    {
        public int SPECIFICATIONSID { get; set; }
        public string  SPECIFICATIONSNAME { get; set; }
        public string SPECIFICATIONSVALUE { get; set; }
        public int ProductID { get; set; }
    }


}
