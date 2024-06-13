using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public class Cow : Animal
    {
        public override string Eat()
        {
            return "cỏ";
        }

        public override string Sound()
        {
            return "be be";
        }
    }
}
