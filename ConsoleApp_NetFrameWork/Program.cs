using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_NetFrameWork
{
    public class Program
    {
        //static void ThamChieu(out int a)
        //{
        //    // a chính là bản sao của biến myNumber 
        //    a = 100;
        //}


        static int TinhTongHaiSo(int soThuNhat, int soThuHai)
        {
            // code xử lý của hàm
            return soThuNhat + soThuHai;
        }

        static void ThamChieu_WithRef(ref int x)
        {
            x = x * x;
            Console.WriteLine(x);
        }

        static int ThamChieu_WithOut(out int x_ref)
        {
            x_ref = 10000;
            return 5;
        }

        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        static bool CheckValidateInput(string input)
        {
            var result = true;
            // Check xem dữ liệu đầu vào có bị trống không
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            //kiểm tra xem có ký tự đặc biệt hoặc dữ liệu nguy hiểm không
            if (!CheckXSSInput(input))
            {
                return false;
            }
            // kiểm tra xem có phải kiểu số không
            int n;
            bool isNumeric = int.TryParse(input, out n);

            if (!isNumeric)
            {
                return false;
            }

            // CTRL+K+U : uncomment
            // CTRL+K+C : comment
            // CTRL+K+D : fomat code 

            return result;
        }

        public static void UserInput(string s)
        {
            if (s.Length > 1)
            {
                throw new DataTooLongExeption();
            }

            //Other code - no exeption
        }


        static void Main(string[] args)
        {

            int myNumber = 10;
            int myNumber2 = 20;

            // code 

            myNumber = 20;

            int myNumber3 = myNumber;//

            Console.WriteLine("befor:{0} ", myNumber);

            ThamChieu_WithRef(ref myNumber);

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

            //Console.WriteLine("=========BUOI 3===============");

            int soThuNhat = 0;
            Console.WriteLine("nhap text");
            var firstInput = Console.ReadLine();
            //var validateInput = CheckValidateInput(firstInput);
            //if (!validateInput)
            //{
            //    Console.WriteLine("dữ liệu đầu vào hông hợp lệ");
            //}
            //else
            //{
            //    soThuNhat = Convert.ToInt32(firstInput);
            //    int tong = TinhTongHaiSo(soThuNhat, 20);
            //    Console.WriteLine("tong 10 + 20 = {0},", tong);

            //}

            int x1;
            // x_ref chính là tham chiếu của biến x1 
            int result = ThamChieu_WithOut(out x1);
            Console.WriteLine("x1 ThamChieu_WithOut {0},", x1);
            Console.WriteLine("result ThamChieu_WithOut {0},", result);

            int zero = 2;
            try
            {
                UserInput(firstInput);
            }
            catch (DataTooLongExeption ex)
            {
                Console.WriteLine("Message :{0}", ex.Message);
                Console.WriteLine("StackTrace :{0}", ex.StackTrace);
                Console.WriteLine("Source :{0}", ex.Source);
            }
            finally
            {
                Console.WriteLine("finally finally");
            }
           

            // CTRL+ K + D
            Console.ReadKey();
        }
    }
}
