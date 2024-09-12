using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.Dapper;
using BE_2505.DataAccess.Netcore.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class AccountDapper_Impl : BaseApplicationService, IAccountDapper_DAL
    {
        public AccountDapper_Impl(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<ReturnData> Account_Insert(AccountInsertRequestData requestData)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Account>> GetAccounts(AccountGetListRequestData requestData)
        {
            var list = new List<Account>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", requestData.UserName);
                list = await DbConnection.QueryAsync<Account>("SP_Account_GetAll", parameters);

            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }
    }
}
