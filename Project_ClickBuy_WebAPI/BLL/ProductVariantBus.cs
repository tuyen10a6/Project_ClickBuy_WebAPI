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
        public bool AddProductVariant(ProductVariantModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeteteProductVariant(int VariantID)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariantModel> GetAllProductVariant()
        {
            throw new NotImplementedException();
        }

        public ProductVariantModel GetIDProductVariant(int productVariantID)
        {
            return _res.GetIDProductVariant(productVariantID);

        }

        public List<ProductVariantModel> SearchProductVariant(string VariantName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductVariant(ProductVariantModel model)
        {
            throw new NotImplementedException();
        }
    }
}
