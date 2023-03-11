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
    public class BrandRespository : IBrandRepository
    {
        private IDatabaseHelper _databaseHelper;
        public BrandRespository (IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public bool CreateBrand(BrandModel model)
        {
            var requestJson = model != null ? MessageConvert.SerializeObject(model) : null;
            try
            {
                string msgError = "";
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Brand_create",
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
        public bool DeleteBrand(int BrandID)
        {
            try
            {
                string msgError = "";
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteBrand",
                    "@BrandID", BrandID
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

        public List<BrandModel> GetAllBrand()
        {
            var proName = "GetAllBrand";
            var result = _databaseHelper.ExecuteSProcedureReturnDataTable(proName);
            var ListBrand = result.ConvertTo<BrandModel>().ToList();
            return ListBrand;
        }

        public List<SanPhamModel> GetProductASC(int BrandID)
        {

            var dt = _databaseHelper.ExecuteSProcedureReturnDataTable("GetProductsByASCPriceByBrandID", "@BrandID", BrandID);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }

        public List<SanPhamModel> GetProductDesc(int BrandID)
        {
            var dt = _databaseHelper.ExecuteSProcedureReturnDataTable("GetProductsByDESCPriceByBrandID", "@BrandID", BrandID);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }

        public List<SanPhamModel> GetProductMeMory(int BrandID, int Memory)
        {
            var dt = _databaseHelper.ExecuteSProcedureReturnDataTable("GetMeMoryBrandID", "@BrandID", BrandID, "@Memory", Memory);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }

        public List<SanPhamModel> GetProductPrice(int BrandID, int min, int max)
        {
            var dt = _databaseHelper.ExecuteSProcedureReturnDataTable("GetProductsByPriceRangeBrandID", "@BrandID", BrandID, "@MinPrice", min, "@MaxPrice", max);

            // Chuyển đổi kết quả trả về sang danh sách các đối tượng SanPhamModel
            var sanPhams = dt.ConvertTo<SanPhamModel>().ToList();
            return sanPhams;
        }

        public List<SanPhamModel> GetSanPhamByBrandID(int BrandID)
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable("GetProductsByBrands", "@BrandId", BrandID);
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

        public List<BrandModel> SearchBrandName(string BrandName)
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable("SearchBrandByBrandName", "BrandName", BrandName);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var sanPham = dt.ConvertTo<BrandModel>().ToList();
                return sanPham;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBrand(BrandModel model)
        {
            var requestJson = model != null ? MessageConvert.SerializeObject(model) : null;
            try
            {
                string msgError = "";
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_brand_update",
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
