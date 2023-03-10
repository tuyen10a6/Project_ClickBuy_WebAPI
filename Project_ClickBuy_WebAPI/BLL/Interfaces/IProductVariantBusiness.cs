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
        bool AddProductVariant(int productID, List<ProductVariantModel> variants);

        bool UpdateProductVariant(ProductVariantModel model);
        bool DeteteProductVariant(int VariantID);
        List<ProductVariantModel> GetProductVariantIdProduct(int ProductID);

        List<ProductVariantModel> SearchProductVariant(string VariantName);
        ProductVariantModel GetIDProductVariant(int productVariantID);
    }
}
