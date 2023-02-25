using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
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
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "AddProduct",
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

        public List<SanPhamModel> GetAllSanPham()
        {
            string spName = "GetAllProducts";
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable(spName);
            var listSanPham = dt.ConvertTo<SanPhamModel>().ToList();
            return listSanPham;
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
    }
}
