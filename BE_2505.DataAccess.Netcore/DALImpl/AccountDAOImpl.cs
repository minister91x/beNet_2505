using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class AccountDAOImpl : IAccountDAO
    {
        public async Task<AccountLoginResponseData> Login(AccountLoginRequestData requestData)
        {
            var retunData = new AccountLoginResponseData();
            try
            {
                var passwordHash = BE_2505.Common.Netcore.Security.GetSaltedHash(requestData.Password);
                retunData.ResponseMessenger = passwordHash;
            }
            catch (Exception ex)
            {

                throw;
            }

            return retunData;
        }
    }
}
