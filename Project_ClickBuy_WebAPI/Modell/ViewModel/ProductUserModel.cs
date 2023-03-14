using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickBuy.Model.ViewModel
{
    public class ProductUserModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int? PRICE { get; set; }
    }

}
