using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public class Bird : Animal
    {
       
        public override string Eat()
        {
            return "Cám con cò";
        }

        public override string Sound()
        {
            return "chip chip";
        }

        public override string Sound2()
        {
            return "chip2 chip2";
        }
    }
}
