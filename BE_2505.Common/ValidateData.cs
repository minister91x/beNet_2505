using ConsoleApp_NetFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public class ValidateData
    {
        public bool CheckIputData(string inpustring)
        {
            if (string.IsNullOrEmpty(inpustring))
            {
                return false;
            }


            //var myclass = new MyClass_Dilivery();
            //myclass.Id = 123;
            return true;
        }
    }
}
