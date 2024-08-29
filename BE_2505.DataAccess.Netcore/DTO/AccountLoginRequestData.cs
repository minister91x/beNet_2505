using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class AccountLoginRequestData
    {
        [Required(ErrorMessage = "UserName không được trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được trống")]
        public string Password { get; set; }
    }
    public class AccountLogOutRequestData
    {
        public string IP { get; set; }
        public string token { get; set; }
    }
    public class AccountLoginResponseData : ReturnData
    {
        public Account account { get; set; }
        public string token { get; set; }
        public string refeshtoken { get; set; }
    }

    public class AccountLogin_UpdateRefeshTokenRequestData
    {
        public int UseId { get; set; }
        public string RefeshToken { get; set; }
        public DateTime RefeshTokenExpriredTime { get; set; }
    }
}
