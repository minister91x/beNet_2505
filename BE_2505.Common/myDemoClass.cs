using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_NetFrameWork
{
    public class myDemoClass
    {
        //Thuộc tính 
        public int Id { get; set; }// private 
        public string Name { get; set; }
        // contructor
        public myDemoClass()
        {

        }
        public myDemoClass(int id)
        {

        }
        // phương thức 
       public void Run()
        {
            Console.WriteLine("running" + Id);
        }
    }
}
