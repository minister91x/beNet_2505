using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class ProductRepository : IProductRepository
    {
        private BE_25_05DbContext _context;

        public ProductRepository(BE_25_05DbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                list = _context.product.ToList();
                if (!string.IsNullOrEmpty(requestData.ProdductName))
                {
                    list = list.FindAll(s => s.ProdductName.Contains(requestData.ProdductName));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public async Task<ReturnData> ProductInsertUpdate(Product product, int CreaterUser)
        {
            var returnData = new ReturnData();
            try
            {
                if (product == null
                    || string.IsNullOrEmpty(product.ProdductName)
                    || !BE_2505.Common.Netcore.Validation.CheckXSSInput(product.ProdductName)
                     || product.Price <= 0
                     || string.IsNullOrEmpty(product.Image))
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                // xử lý ảnh 


                // thêm mới
                if (product.ProdductID == 0)
                {
                    product.CreatedUser = 1;
                    product.CreatedTime = DateTime.Now;

                    _context.product.Add(product);
                    var rs = _context.SaveChanges();
                    if (rs <= 0)
                    {
                        returnData.ResponseCode = -2;
                        returnData.ResponseMessenger = "Thêm mới thất bại";
                        return returnData;
                    }

                    returnData.ResponseCode = 1;
                    returnData.ResponseMessenger = "Thêm thành công";
                    return returnData;
                }
                else
                {
                    // cập nhật
                    var productDB = _context.product.Where(s => s.ProdductID == product.ProdductID).FirstOrDefault();

                    if (productDB == null || productDB.ProdductID <= 0)
                    {
                        returnData.ResponseCode = -3;
                        returnData.ResponseMessenger = "Không tồn tại sản phẩm cần update trên hệ thống";
                        return returnData;
                    }

                    productDB.ProdductName = product.ProdductName;
                    productDB.Price = product.Price;

                    _context.product.Update(productDB);

                    var rs = _context.SaveChanges();

                    if (rs <= 0)
                    {
                        returnData.ResponseCode = -2;
                        returnData.ResponseMessenger = "Cập nhật thất bại";
                        return returnData;
                    }

                    returnData.ResponseCode = 1;
                    returnData.ResponseMessenger = "Cập nhật thành công";
                    return returnData;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
