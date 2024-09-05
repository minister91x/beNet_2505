using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;
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
        public IProductGenericRepository _productGenericRepository { get; set; }
        public IAccountADO_DAL _accountADO { get; set; }
        public IAccountDapper_DAL _accountDapper_DAL { get; set; }

        public BE_25_05DbContext _context;

        public UnitOfWork_BE_2505(IProductRepository productRepository, 
            BE_25_05DbContext context, IProductGenericRepository productGenericRepository,
            IAccountADO_DAL accountADO, IAccountDapper_DAL accountDapper_DAL)
        {
            _productRepository = productRepository;
            _productGenericRepository = productGenericRepository;
            _context = context;
            _accountADO = accountADO;
            _accountDapper_DAL = accountDapper_DAL;
        }

        public int SaveChange()
        {
          return  _context.SaveChanges();
        }
    }
}
