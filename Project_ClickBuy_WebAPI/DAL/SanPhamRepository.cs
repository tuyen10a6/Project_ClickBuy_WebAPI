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
        public List<SanPhamModel> GetAllSanPham()
        {
            string spName = "GetAllSanPham";
            var dt = _dbHelper.ExecuteSProcedureReturnDataTable(spName);
            var listSanPham = dt.ConvertTo<SanPhamModel>().ToList();
            return listSanPham;
        }
    }
}
