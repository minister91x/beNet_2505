using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class ClassB
    {
        public ClassB(int a)
        {

        }
        public int Tong()
        {
            ClassA ca = new ClassA();
            return ca.TinhTong();
        }
    }
}
