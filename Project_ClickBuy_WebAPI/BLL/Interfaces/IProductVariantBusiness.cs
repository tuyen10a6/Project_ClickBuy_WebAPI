using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductVariantBusiness
    {
        List<ProductVariantModel> GetAllProductVariant();
        bool AddProductVariant(ProductVariantModel model);
        bool UpdateProductVariant(ProductVariantModel model);
        bool DeteteProductVariant(int VariantID);

        List<ProductVariantModel> SearchProductVariant(string VariantName);
        ProductVariantModel GetIDProductVariant(int productVariantID);
    }
}
