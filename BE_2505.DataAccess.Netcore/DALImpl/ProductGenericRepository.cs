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
    public class ProductGenericRepository : GenericRepositorycs<Product>, IProductGenericRepository
    {
        public ProductGenericRepository(BE_25_05DbContext context) : base(context)
        {
        }
    }
}
