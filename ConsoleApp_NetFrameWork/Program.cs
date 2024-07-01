using BE_2505.Common;
using BE_2505.DataAccess.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

        public int Cong(int a, int b)
        {
            return a + b;
        }

        public int Cong(int a)
        {
            return a + 10;
        }

        public int Cong(int a, int b, int c)
        {
            return a + b + c;
        }


        public long Cong(long a, long b)
        {
            return a + b;
        }
        struct Student_Struct
        {
            // Thuộc tính
            public string _name;
            public int _id;
            public HinhHoc _hinhhoc;


            // Hàm khởi tạo - Không có kiểu dữ liệu trả về
            public Student_Struct(string Name, int Id, HinhHoc hinhhoc)
            {
                this._name = Name;
                this._id = Id;
                this._hinhhoc = hinhhoc;
            }

            // Phương thức
            public string Run()
            {
                return _name + " is running";
            }
        }

        struct HinhHoc
        {
            public string _ten_hinh;
            public int _loai_hinh;
            public int _chieudai;
            public int _chieurong;
            public HinhHoc(string TenHinh, int LoaiHinh, int ChieuDai, int ChieuRong)
            {
                _ten_hinh = TenHinh;
                _loai_hinh = LoaiHinh;
                _chieudai = ChieuDai;
                _chieurong = ChieuRong;
            }
            public int DienTich()
            {
                if (_loai_hinh == 1)
                {
                    return (_chieudai + _chieurong) * 2;
                }

                return 0;
            }


        }


        enum TrangThai_GiaoDich
        {
            THANH_CONG = 1,
            THATBAI = 2,
            DA_HUY = 2
        }

        HinhHoc HinhCuaToi(HinhHoc hinhHoc)
        {
            return new HinhHoc();
        }

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

        // T là kieu dữ liệu đại diện cho tất cả các kiểu dữ liệu còn lại 
        public static void ham_cua_toi<T>(ref T a, ref T b)
        {
            T temp = a; // 1
            a = b; // 2
            b = temp; // 3
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
            //int result = ThamChieu_WithOut(out x1);
            //Console.WriteLine("x1 ThamChieu_WithOut {0},", x1);
            //Console.WriteLine("result ThamChieu_WithOut {0},", result);

            //int zero = 2;
            //try
            //{
            //    UserInput(firstInput);
            //}
            //catch (DataTooLongExeption ex)
            //{
            //    Console.WriteLine("Message :{0}", ex.Message);
            //    Console.WriteLine("StackTrace :{0}", ex.StackTrace);
            //    Console.WriteLine("Source :{0}", ex.Source);
            //}
            //finally
            //{
            //    Console.WriteLine("finally finally");
            //}


            // buổi 4 

            //List<int> students = new List<int>()
            //{
            //    1,2,3,6,7
            //};
            //char[] my_string = { 'H', 'e', 'l', 'l', 'o', '\0' };

            //var values = students[2];
            //students.Sort();

            ////var std = new Student_Struct("Mr Quân", 1245);
            //Console.WriteLine("nhap tên");
            //var firstInput = Console.ReadLine();

            //Console.WriteLine("nhap id");
            //var id_input = Console.ReadLine();

            //var std = new HinhHoc();
            //std._ten_hinh = firstInput;
            //std._loai_hinh = Convert.ToInt32(id_input);

            //Console.WriteLine("Struct Name={0}", std._ten_hinh);
            //Console.WriteLine("Struct id={0}", std._loai_hinh);

            //int TrangThai = 0;

            //var tt = TrangThai_GiaoDich.THANH_CONG;
            //var tt2 = (int)TrangThai_GiaoDich.THANH_CONG;

            //Console.WriteLine("tt={0}", tt);
            //Console.WriteLine("tt2={0}", tt2);

            //if (TrangThai == (int)TrangThai_GiaoDich.THANH_CONG)
            //{

            //}
            //if (TrangThai == (int)TrangThai_GiaoDich.THATBAI)
            //{

            //}
            //if (TrangThai == 3)
            //{

            //}


            //switch (TrangThai)
            //{
            //    case 1: break;
            //    case 2: break;
            //    case 3: break;
            //}

            //var bai24 = new BaiSo24();
            //bai24.GiaiBai24();

            //Console.WriteLine("----------------Buổi 5-----------------");

            //var datetime = DateTime.Now; // UTC+ 7
            //var datetimeUtcNow = DateTime.UtcNow; // UTC +0

            //Console.WriteLine("datetime={0}", datetime.ToString("dd/MM/yyyy HH:mm:ss"));
            //Console.WriteLine("datetimeUtcNow={0}", datetimeUtcNow.ToString("dd/MM/yyyy HH:mm:ss"));

            //var newLocalDate = datetime.AddDays(1);
            //Console.WriteLine("newLocalDate={0}", newLocalDate.ToString("dd/MM/yyyy HH:mm:ss"));

            //var newSubLocalDate = datetime.AddDays(-1);
            //Console.WriteLine("newSubLocalDate={0}", newSubLocalDate.ToString("dd/MM/yyyy HH:mm:ss"));

            //var myTimeSpan = new TimeSpan(-1, -1, -10, 0, 0);

            //var newDateWithTimeSpan = datetime.Add(myTimeSpan);
            //Console.WriteLine("newDateWithTimeSpan={0}", newDateWithTimeSpan.ToString("dd/MM/yyyy HH:mm:ss"));

            // Thời điểm hiện tại.
            DateTime aDateTime = DateTime.Now;

            // Thời điểm năm 2000
            DateTime y2K = new DateTime(1991, 1, 1);

            // Khoảng thời gian từ năm 2000 tới nay.
            TimeSpan interval = aDateTime.Subtract(y2K);

            double days = interval.TotalDays;
            Console.WriteLine("days={0}", interval.TotalDays);
            Console.WriteLine("Hours={0}", interval.Hours);
            Console.WriteLine("Seconds={0}", interval.Seconds);

            //string[] formattedStrings = aDateTime.GetDateTimeFormats();

            //foreach (string format in formattedStrings)
            //{
            //    Console.WriteLine(format);
            //}

            string day_str = "06/06/2024";

            //var datefromString = DateTime.ParseExact(day_str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Console.WriteLine("datefromString={0}", datefromString.AddDays(1).ToString("dd/MM/yyyy"));


            //DateTime dateValue;
            //if(!DateTime.TryParseExact(day_str, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue)){
            //    Console.WriteLine("Not Datime");
            //}
            //else
            //{
            //    Console.WriteLine("is Datime");
            //}
            //string _str = "Nguyen/trong/Quan";
            //var arrStr = _str.Split('/');
            //foreach (var item in arrStr)
            //{
            //    Console.WriteLine("{0}", item.ToUpper());
            //}

            //var newstr = _str + "abc";
            //Console.WriteLine("newstr={0}", newstr);

            //var builder = new StringBuilder();
            //builder.Append(_str);
            //builder.Append("abc");

            //Console.WriteLine("builder={0}", builder.ToString());

            Console.WriteLine("-----------------6-----------------------");
            Console.OutputEncoding = Encoding.UTF8;
            //var bai24 = new BaiSo24();
            //bai24.ReadExcelFile();
            //int a = 10;
            //int b = 20;
            //Console.WriteLine("a={0}", a);
            //Console.WriteLine("b={0}", b);

            //ham_cua_toi<int>(ref a, ref b);

            //Console.WriteLine("after a={0}", a);
            //Console.WriteLine("after b={0}", b);

            //string a_str = "MR";
            //string b_str = "QUAN";

            //Console.WriteLine("a_str={0}", a_str);
            //Console.WriteLine("b_str={0}", b_str);

            //ham_cua_toi<string>(ref a_str, ref b_str);


            //Console.WriteLine("after a_str={0}", a_str);
            //Console.WriteLine("after b_str={0}", b_str);


            //ArrayList arrList = new ArrayList() { 1, "5", 2.5, true };
            //arrList.Add(true);
            //arrList.Add("124");
            //arrList.Add(10.6);
            //foreach (var item in arrList)
            //{
            //    Console.WriteLine("item={0}", item);

            //}

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("MyKey", "123");
            //dic.Add("MyKey1", "aaaaa");

            //Hashtable hashtable = new Hashtable();

            //hashtable.Add("Key1", "Value1");
            //hashtable.Add("Key2", "Value2");

            //foreach (DictionaryEntry item in hashtable)
            //{
            //    Console.WriteLine("Key: {0} - Value: {1}",
            //        item.Key, item.Value);
            //}

            //foreach (var key in hashtable.Keys)
            //{
            //    Console.WriteLine("Key: {0} ", key);
            //}

            //SortedList mySL = new SortedList();
            //mySL.Add("Third", "!");
            //mySL.Add("abc", "1234");

            //Console.WriteLine("mySL");
            //Console.WriteLine(" Count: {0}", mySL.Count);
            //Console.WriteLine(" Capacity: {0}", mySL.Capacity);
            //Console.WriteLine(" Keys and Values:");
            //Console.WriteLine("\t-KEY-\t-VALUE-");

            //for (int i = 0; i < mySL.Count; i++)
            //{
            //    Console.WriteLine("\t{0}:\t{1}",
            //        mySL.GetKey(i),
            //        mySL.GetByIndex(i));
            //}


            //Stack myStack = new Stack();
            //myStack.Push("Hello");
            //myStack.Push("World");
            //myStack.Push("!");

            //Console.WriteLine("\t myStack Count: {0}", myStack.Count);

            //foreach (Object obj in myStack)
            //{
            //    Console.Write(" {0} \n", obj);
            //}

            //Console.Write(" -----------Queue---------------- \n");
            //Queue myQ = new Queue();
            //myQ.Enqueue("Hello");
            //myQ.Enqueue("World");
            //myQ.Enqueue("!");

            //foreach (Object obj in myQ)
            //{
            //    Console.Write(" {0} \n", obj);
            //}

            ////=------------------------------Buổi 7----------------------


            //var myclass = new MyClass_Dilivery();
            //myclass.Id = 1;
            //myclass.Name = "XE 4 CHỖ";

            //var myclass2 = new MyClass_Dilivery();
            //myclass.Id = 2;
            //myclass.Name = "XE 5 CHỖ";



            //var staticclass = StaticClass.TestStatic();
            //var staticclass_properties = StaticClass.StaticName;

            //var bird = new Bird();
            //bird.Name = "Bird";
            //bird.Eat();


            //var xekhach = new XeKhach();



            //var xekhach2 = new XeKhach();
            //xekhach2._brand = "toyota";
            //xekhach2._model = "lexus";
            //xekhach2._year = 2024;

            //// c3:
            //var xekhach3 = new XeKhach
            //{
            //    _brand = "TOYOTA",
            //    _model = "LEXUS",
            //    _year = 2024
            //};

            //Console.Write("infor {0}", xekhach.display_info());

            Console.Write("Buoi 8-----------------");
            // nhấn F10 trên bàn phím để chạy từng dòng 
            // Nhần F11 TRÊN bàn phím để nhày vào hàm 
            var student = new BE_2505.DataAccess.DALImpl.StudentManager();

            var student_Req = new BE_2505.DataAccess.DTO.Student
            {
                Id = Guid.NewGuid(),
                Name = "MR QUÂN",
                DateOfBirth = DateTime.Now
            };
            //var student_Req = new BE_2505.DataAccess.DTO.Student();
            //student_Req.SetFullName("MR QUÂN");

            // Console.Write("FullName= {0}", student_Req.GetFullName());

            //var result = student.Student_Insert(student_Req);

            //if (result.ResponseCode < 0)
            //{
            //    Console.Write("Thông báo lỗi {0}", result.ResponseMessenger);
            //}
            //else
            //{
            //    Console.Write("Thông báo: {0}", result.ResponseMessenger);
            //    Console.Write("id student: {0}", result.studentId);
            //}

            //var maydell = new MayTinhDELL();

            //maydell.ChieuDai = 100;
            //maydell.ChieuRong = 200;

            //Console.Write("ChieuDai maydell: {0}", maydell.ChieuDai +"\n");
            //Console.Write("ChieuRong maydell: {0}", maydell.ChieuRong + "\n");


            //var maylenovo = new MayTinhLENOVO();

            //maylenovo.ChieuDai = 120;
            //maylenovo.ChieuRong = 250;

            //Console.Write("ChieuDai maylenovo: {0}", maylenovo.ChieuDai + "\n");
            //Console.Write("ChieuRong maylenovo: {0}", maylenovo.ChieuRong + "\n");


            //    var classb = new ClassB();

            // Console.Write("ClassB Tong: {0}", classb.Tong() + "\n");

            throw new ArgumentException("Tuổi phải nằm trong khoảng từ 22 đến 60.");
            Console.ReadKey();
        }
    }
}
