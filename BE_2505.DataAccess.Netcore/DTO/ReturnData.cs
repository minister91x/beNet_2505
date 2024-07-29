using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class ReturnData
    {
        public int ResponseCode { get; set; }
        public string ResponseMessenger { get; set; }
    }

    public class StudentInsert_ResponseData : ReturnData
    {
        public Guid studentId { get; set; }
    }
    public class StudentDelete_ResponseData : ReturnData
    {

    }
}
