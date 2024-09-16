using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CleanCodeAccountLoginRequestData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class AccountLogOutRequestData
    {
        public string IP { get; set; }
        public string token { get; set; }
    }

    public class CleanCodeReturnData
    {
        public int ResponseCode { get; set; }
        public string ResponseMessenger { get; set; }
    }
    public class CleanCodeAccountLoginResponseData : CleanCodeReturnData
    {
        public Account account { get; set; }
        public string token { get; set; }
        public string refeshtoken { get; set; }
    }
}
