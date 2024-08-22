using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DAL
{
    public interface IAccountDAO
    {
       Task<AccountLoginResponseData> Login(AccountLoginRequestData requestData);
        Task<int> AccountLogin_UpdateRefeshToken(AccountLogin_UpdateRefeshTokenRequestData requestData);
    }
}
