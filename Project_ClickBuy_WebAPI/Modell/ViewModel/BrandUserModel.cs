using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickBuy.Model.ViewModel
{
    public class BrandUserModel
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
}
