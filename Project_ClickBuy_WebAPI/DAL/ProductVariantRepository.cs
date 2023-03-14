using Azure.Core;
using ClickBuy.Model.ViewModel;
using DAL.Helper;
using Microsoft.Identity.Client;
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
        public bool AddProductVariant(int productID, List<ProductVariantModel> variants)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(variants);
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "AddProductVariant",
                    new SqlParameter("@ProductID", productID),
                    new SqlParameter("@JsonData", jsonData)
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeteteProductVariant(int VariantID)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteProductVariant",
                    "@VariantID", VariantID
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
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
        public List<ProductVariantUserModel> GetProductVariantIdProduct(int ProductID)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductVariantByProduct", "@ProductID", ProductID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var sanPham = dt.ConvertTo<ProductVariantUserModel>().ToList();
                return sanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductVariantModel> SearchProductVariant(string VariantName)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("SearchProductVariant", "@Value", VariantName);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var sanPham = dt.ConvertTo<ProductVariantModel>().ToList();
                return sanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProductVariant(ProductVariantModel model)
        {
            throw new NotImplementedException();
        }

       
    }
}
