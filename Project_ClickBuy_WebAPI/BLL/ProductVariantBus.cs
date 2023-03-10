using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductVariantBus : IProductVariantBusiness
    {
        private IProductVariantRepository _res;
        public ProductVariantBus(IProductVariantRepository res)
        {
            _res = res;
        }
       

        public bool AddProductVariant(int productID, List<ProductVariantModel> variants)
        {
            return _res.AddProductVariant(productID, variants);
        }

        public bool DeteteProductVariant(int VariantID)
        {
            return _res.DeteteProductVariant(VariantID);
        }

        public List<ProductVariantModel> GetAllProductVariant()
        {
            throw new NotImplementedException();
        }

        public ProductVariantModel GetIDProductVariant(int productVariantID)
        {
            return _res.GetIDProductVariant(productVariantID);

        }

        public List<ProductVariantModel> GetProductVariantIdProduct(int ProductID)
        {
            return _res.GetProductVariantIdProduct(ProductID);
        }

        public List<ProductVariantModel> SearchProductVariant(string VariantName)
        {
            return _res.SearchProductVariant(VariantName);
        }

        public bool UpdateProductVariant(ProductVariantModel model)
        {
            throw new NotImplementedException();
        }
    }
}
