using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoriesModel
    {
        public int CategoryID { get; set; } 
        public string CategoryName { get; set; }
    }
    public class GetAllBrandByCategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
    }
    

}
