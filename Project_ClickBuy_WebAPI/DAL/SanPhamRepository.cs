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
    public class SanPhamRepository : ISanPhamRepository
    {
        private IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool AddSanPham(SanPhamModel model)
        {
            var requestJson = model != null ? MessageConvert.SerializeObject(model) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_create",
                "@request", requestJson
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
        public bool UpdateSanPham(SanPhamModel model)
        {
            var requestJson = model != null ? MessageConvert.SerializeObject(model) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_update",
                "@request", requestJson
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
        public bool DeteteSanPham(int productID)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_delete",
                    "@productId", productID
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
        public List<SanPhamModel> GetAllSanPham()
        {
            string spName = "GetAllProducts";
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable(spName);
            var listSanPham = dt.ConvertTo<SanPhamModel>().ToList();
            return listSanPham;
        }
        public SanPhamModel GetIDSanPham(int productID)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductById", "@ProductId", productID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var sanPham = dt.ConvertTo<SanPhamModel>().FirstOrDefault();

                // Lấy danh sách variants
                var dtVariants = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductVariants", "@ProductId", productID);
                if (dtVariants.Rows.Count > 0)
                {
                    sanPham.Variants = dtVariants.ConvertTo<ProductVariants>().ToList();
                }

                // Lấy danh sách attributes
                var dtAttributes = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductSpecifications", "@ProductId", productID);
                if (dtAttributes.Rows.Count > 0)
                {
                    sanPham.Attributes = dtAttributes.ConvertTo<Specification>().ToList();
                }

                return sanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> SearchProduct(string ProductName)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("SearchProducts",
                    "@ProductName", ProductName );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateSanPham(int productID, SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "UpdateProduct",
                    "@ProductID", productID,
                    "@ProductName", model.ProductName,
                    "@CategoryID", model.CategoryID,
                    "@Description", model.Description,
                    "@ImageURL", model.ImageURL,
                    "@BrandID", model.BrandID);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
           }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> GetProductsByPriceRange(int minPrice, int maxPrice)
        {
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductsByPriceRange", "@MinPrice", minPrice, "@MaxPrice", maxPrice);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();

            return sanPhams;
        }

        public List<SanPhamModel> GetProductMemory(int value)
        {
           var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetMeMory" , "@Memory", value);
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }

        public List<SanPhamModel> GetSanPhamByPage(int pageNumber, int pageSize)
        {
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductsPaged", "@PageSize", pageSize, "@PageNumber", pageNumber);
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }
    }
}
