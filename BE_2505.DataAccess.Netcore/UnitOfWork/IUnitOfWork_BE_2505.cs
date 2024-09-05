using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.UnitOfWork
{
    public interface IUnitOfWork_BE_2505
    {
        IProductRepository _productRepository { get; set; }
        IProductGenericRepository _productGenericRepository { get; set; }
        IAccountADO_DAL _accountADO { get; set; }
        IAccountDapper_DAL _accountDapper_DAL { get; set; }
        int SaveChange();
    }
}
