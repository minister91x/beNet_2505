using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DAL
{
    public interface IAccountDapper_DAL
    {
        Task<List<Account>> GetAccounts(AccountGetListRequestData requestData);
        Task<ReturnData> Account_Insert(AccountInsertRequestData requestData);
    }
}
