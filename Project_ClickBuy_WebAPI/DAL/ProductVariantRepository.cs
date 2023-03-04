using Azure.Core;
using DAL.Helper;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductVariantRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
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
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductVariant", "@VariantId", productVariantID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var sanPham = dt.ConvertTo<ProductVariantModel>().FirstOrDefault();


                return sanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetProductVariantIdProduct(int ProductID)
        {
            throw new NotImplementedException();
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
