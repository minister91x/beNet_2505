using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_NetFrameWork
{
    public class Program
    {
        static void ThamChieu(out int a)
        {
            // a chính là bản sao của biến myNumber 
            a = 100;
        }
        static void Main(string[] args)
        {

            int myNumber = 10;
            int myNumber2 = 20;

            // code 

            myNumber = 20;

            int myNumber3 = myNumber;//

            Console.WriteLine("befor:{0} ", myNumber);

            ThamChieu(out myNumber);

            Console.WriteLine("after:{0} ", myNumber);


            //int Thang = 10;
            //switch (Thang)
            //{
            //    case 1 3 6 9:
            //         Console.WriteLine("thang 30 ngày ");
            //        break;
            //    case 2 7 8:

            //        break;


            //}

            if (myNumber == 20)
            {
                Console.WriteLine("bang:{0} ");
            }
            else
            {
                Console.WriteLine("khong bang");
            }

            Console.WriteLine("{0} ", myNumber == 20 ? "bang " : "khong bang");

            var orderStatus = 0;

            var statusName = orderStatus == 0 ? "Khởi tạo" :
                  orderStatus == 1 ? "đã thanh toán"
                : orderStatus == 2 ? "Đã hoàn" : "Đã hủy";


            var lst = new List<Student>();

            var listErr = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                lst.Add(new Student
                {
                    Id = i,
                    Name = "student _" + i
                });
            }


            //for (int i = 0; i < lst.Count; i++)
            //{
            //    Console.WriteLine("{0},", lst[i].Name);
            //}

            //Console.WriteLine("========================");

            //foreach (var item in lst)
            //{
            //    Console.WriteLine("{0},", item.Name);
            //}


            int soThuNhat = 0;
            soThuNhat = Convert.ToInt32(Console.ReadLine());



            // CTRL+ K + D
            Console.ReadKey();
        }
    }
}
