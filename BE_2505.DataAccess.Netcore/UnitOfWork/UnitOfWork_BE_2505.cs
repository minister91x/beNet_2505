using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.UnitOfWork
{
    public class UnitOfWork_BE_2505 : IUnitOfWork_BE_2505
    {
        public IProductRepository _productRepository { get; set; }
        public BE_25_05DbContext _context;

        public UnitOfWork_BE_2505(IProductRepository productRepository, 
            BE_25_05DbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public int SaveChange()
        {
          return  _context.SaveChanges();
        }
    }
}
