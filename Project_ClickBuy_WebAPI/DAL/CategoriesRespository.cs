using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriesRespository : ICategoriesRepository
    {
        private IDatabaseHelper _dbHelper;
        public CategoriesRespository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool CreateSanPham(CategoriesModel model)
        {
            var requestJson = model != null ? MessageConvert.SerializeObject(model) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_category_create",
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

        public bool DeleteCategory(int CategoryID)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteCategory",
                    "@CategoryID", CategoryID
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
        public List<GetAllBrandByCategoryModel> getAllBrandByCategoryModels(int CategoryID)
        {
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetAllBrandByCategoryID", "@CATEGORYID", CategoryID);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<GetAllBrandByCategoryModel>().ToList();
            return sanPhams;
        }

        public List<CategoriesModel> GetAllCate()
        {
            string spName = "GetAllDanhMuc";
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable(spName);
            var listSanPham = dt.ConvertTo<CategoriesModel>().ToList();
            return listSanPham;
        }

        public List<SanPhamModel> GetProductASC(int CategoryID)
        {
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductsByASCPriceByCategoryID", "@CategoryID", CategoryID);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }

        public List<SanPhamModel> GetProductDesc(int CategoryID)
        {
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductsByDESCPriceByCategoryID",
            "@CategoryID", CategoryID);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }

        public List<SanPhamModel> GetProductMeMory(int CategoryID, int Memory)
        {
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetMeMoryByCategoryID", "@CategoryID", CategoryID, "@Memory", Memory);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }
        public List<SanPhamModel> GetProductPrice(int CategoryID , int min , int max)
        {
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductsByPriceRangeByCategoryID", "@CategoryID" , CategoryID, "@MinPrice", min, "@MaxPrice", max);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }
        public List<SanPhamModel> GetSanPhamByCategoryID(int CategoryID)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductsByCategory", "@CategoryId", CategoryID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var sanPham = dt.ConvertTo<SanPhamModel>().ToList();
                return sanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPhamModel> PagingByCategory(int CategoryID, int PageSize, int PageNumber)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductsByCategoryPaged", 
                    "@CategoryID", CategoryID,
                    "@PageSize", PageSize,
                    "@PageNumber", PageNumber
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var sanPham = dt.ConvertTo<SanPhamModel>().ToList();
                return sanPham;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateSanPham(CategoriesModel model)
        {
            var requestJson = model != null ? MessageConvert.SerializeObject(model) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_category_update",
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
    }
}
