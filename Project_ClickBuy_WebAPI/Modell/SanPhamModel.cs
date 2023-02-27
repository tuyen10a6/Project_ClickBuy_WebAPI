using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SanPhamModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateCreated { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public List<ProductVariantModel> Variants { get; set; }
        public List<ProductAttributeModel> Attributes { get; set; }
    }

    public class ProductVariantModel
    {
        public int VariantId { get; set; }
        public int ProductId { get; set; }
        public string Color { get; set; }
        public string StorageCapacity { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductAttributeModel
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public List<ProductAttributeValueModel> AttributeValues { get; set; }
    }

    public class ProductAttributeValueModel
    {
        public int AttributeValueId { get; set; }
        public int AttributeId { get; set; }
        public int VariantId { get; set; }
        public string Value { get; set; }
    }


}
