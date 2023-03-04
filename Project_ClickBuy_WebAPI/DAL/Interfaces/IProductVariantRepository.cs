using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;


namespace DAL
{
    public interface IProductVariantRepository
    {
        List <ProductVariantModel> GetAllProductVariant();
        bool AddProductVariant(ProductVariantModel model);
        bool UpdateProductVariant(ProductVariantModel model);
        bool DeteteProductVariant(int VariantID);
        bool GetProductVariantIdProduct(int ProductID);

        List<ProductVariantModel> SearchProductVariant(string VariantName);
        ProductVariantModel GetIDProductVariant(int productVariantID);
    }
}
