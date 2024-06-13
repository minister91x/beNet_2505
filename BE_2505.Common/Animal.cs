using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public string Eat13()
        {
            return "test1233";
        }
        public abstract string Eat();
        public abstract string Sound();

        public virtual string Sound2()
        {
            return "123";
        }
    }
}
