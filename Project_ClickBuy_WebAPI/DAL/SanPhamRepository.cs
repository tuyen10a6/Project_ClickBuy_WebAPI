using DAL.Helper;
using Model;
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

       
        public bool DeteteSanPham(int productID)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteProduct",
                    "@ProductID", productID);
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
        public SanPhamModel GetIDSanPham(int productID)
        {
            var product = new SanPhamModel();

            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable("GetProductDetails", "@ProductId", productID);

                if (dt.Rows.Count > 0)
                {
                    // Lấy dữ liệu chính cho sản phẩm
                    var row = dt.Rows[0];

                    product.ProductId = Convert.ToInt32(row["ProductID"]);
                    product.ProductName = row["ProductName"].ToString();
                    product.Description = row["Description"].ToString();
                    product.ImageURL = row["ImageURL"].ToString();
                    product.DateCreated = Convert.ToDateTime(row["DateCreated"]);
                    product.BrandID = Convert.ToInt32(row["BrandID"]);
                    product.CategoryID = Convert.ToInt32(row["CategoryID"]);

                    // Lấy danh sách các biến thể của sản phẩm
                    // Lấy danh sách các biến thể của sản phẩm
                    var variants = dt.AsEnumerable()
                        .GroupBy(r => r.Field<int>("VariantID"))
                        .Select(g => new ProductVariantModel()
                        {
                            VariantId = g.Key,
                            ProductId = g.First().Field<int>("ProductID"),
                            Color = g.First().Field<string>("Color"),
                            StorageCapacity = g.First().Field<string>("StorageCapacity"),
                            Price = g.First().Field<decimal>("Price")
                        })
                        .ToList();
                    product.Variants = variants;


                    // Lấy danh sách các thuộc tính của sản phẩm
                    var attributes = new List<ProductAttributeModel>();
                    foreach (DataRow aRow in dt.Rows)
                    {
                        var attributeId = Convert.ToInt32(aRow["AttributeID"]);
                        var attributeName = aRow["AttributeName"].ToString();
                        var attributeValue = new ProductAttributeValueModel()
                        {
                            AttributeValueId = Convert.ToInt32(aRow["AttributeValueID"]),
                            AttributeId = attributeId,
                            VariantId = Convert.ToInt32(aRow["VariantID"]),
                            Value = aRow["Value"].ToString()
                        };

                        // Kiểm tra xem thuộc tính đã tồn tại trong danh sách chưa
                        var attribute = attributes.FirstOrDefault(a => a.AttributeId == attributeId);
                        if (attribute == null)
                        {
                            attribute = new ProductAttributeModel()
                            {
                                AttributeId = attributeId,
                                AttributeName = attributeName,
                                AttributeValues = new List<ProductAttributeValueModel>()
                            };
                            attributes.Add(attribute);
                        }
                        attribute.AttributeValues.Add(attributeValue);
                    }
                    product.Attributes = attributes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;

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
    }
}
