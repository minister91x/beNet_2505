using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DAL
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(ProductGetListRequestData requestData);
        Task<ReturnData> ProductInsertUpdate(Product product, int CreaterUser);
    }
}
