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
