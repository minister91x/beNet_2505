using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class User_Session
    {
        [Key]
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public string DeviceID { get; set; }
        public string IP { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
