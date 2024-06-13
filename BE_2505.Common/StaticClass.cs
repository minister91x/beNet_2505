using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public static class StaticClass
    {
        public static string StaticName { get; set; }
        public static string TestStatic()
        {
            return "stactic class";
        }
    }
}
