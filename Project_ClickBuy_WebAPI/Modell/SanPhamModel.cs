﻿using System;
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
        public int CategoryID { get; set; }
        public string?  Description { get; set; }
        public string? ImageURL { get; set; }
       public int   BrandID { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
