using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class AccountLoginRequestData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AccountLoginResponseData : ReturnData
    {
    }
}
