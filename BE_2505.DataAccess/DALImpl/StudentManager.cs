using BE_2505.DataAccess.DAL;
using BE_2505.DataAccess.DBContext;
using BE_2505.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.DALImpl
{
    public class StudentManager : IStudentDAL
    {
        List<Student> students = new List<Student>();
        MyShopDbContext _context = new MyShopDbContext();
        public List<Student> GetStudents()
        {
            return _context.student.ToList();
        }
        public StudentInsert_ResponseData StudentInsert_EF(Student requestData)
        {
            var returnData = new StudentInsert_ResponseData();
            try
            {
                // Bước 1: Kiểm tra đầu vào 
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.Name))
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Tên không được trống!";
                    return returnData;
                }

                // Bước 2: Check ký tự đặc biệt , ... xss 

                var checkName = new BE_2505.Common.ValidateData().CheckXSSInput(requestData.Name);
                if (!checkName)
                {
                    returnData.ResponseCode = -2;
                    returnData.ResponseMessenger = "Tên không được chưa ký tự đặc biệt!";
                    return returnData;
                }

                //Bước 3: Check trùng 

                if (students.Count > 0)
                {
                    var studentExist = 0;
                    foreach (var student in students)
                    {
                        if (student.Name == requestData.Name)
                        {
                            studentExist = 1;
                            break;
                        }

                    }

                    if (studentExist > 0)
                    {
                        returnData.ResponseCode = -3;
                        returnData.ResponseMessenger = "Tên đã tồn tại trên hệ thống";
                        return returnData;
                    }

                }

                //Bước 4: Thực hiện Insert 
                _context.student.Add(requestData);
                _context.SaveChanges();

                returnData.ResponseCode = 1;
                returnData.ResponseMessenger = "Thêm thành công";
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public StudentDelete_ResponseData Student_Remove_EF(int studentId)
        {
            var returnData = new StudentDelete_ResponseData();
            try
            {
                if (studentId <= 0)
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Tên không được trống!";
                    return returnData;
                }

                var student = _context.student.ToList().FindAll(s => s.ID == studentId).FirstOrDefault();
                if(student == null || student.ID <= 0)
                {
                    returnData.ResponseCode = -2;
                    returnData.ResponseMessenger = "Không tồn tại học sinh cần xóa!";
                    return returnData;

                }

                _context.student.Remove(student);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

            returnData.ResponseCode = 1;
            returnData.ResponseMessenger = "Xóa thành công";
            return returnData;

        }

        public List<Student> Baocao()
        {
            var lstBaocao = new List<Student>();
            try
            {
                students = students.OrderBy(s => s.Name).ToList();
                // Bước 1: 
                for (int i = 0; i < students.Count; i++)
                {
                    var dong_tong_Dautien = new Student { };
                    lstBaocao.Add(dong_tong_Dautien);

                }


                // Bước 2
                for (int i = 0; i < students.Count; i++)
                {
                    var item = students[i];
                    var isExist = lstBaocao.Where(s => s.Name == item.Name).FirstOrDefault() == null ? true : false;
                    if (!isExist)
                    {
                        // tạo ra cái object tổng của tuwngfnguowif 

                        var item_baocao = lstBaocao[i - 1]; // ví trí trức đó
                        // tính tổng theo người 
                       // var tong_theo_nguoi = lstBaocao.Where(s => s.Name == item_baocao.Name)
                       // /    .Sum(s => s.SolUONG);


                       // var dong_tong_theo_nguoi = new Student { SolUONG = tong_theo_nguoi };

                       // lstBaocao.Add(dong_tong_theo_nguoi);

                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return lstBaocao;
        }

        public StudentInsert_ResponseData Student_Insert(Student requestData)
        {
            var returnData = new StudentInsert_ResponseData();
            try
            {
                // Bước 1: Kiểm tra đầu vào 
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.Name))
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Tên không được trống!";
                    return returnData;
                }


                // Bước 2: Check ký tự đặc biệt , ... xss 

                var checkName = new BE_2505.Common.ValidateData().CheckXSSInput(requestData.Name);
                if (!checkName)
                {
                    returnData.ResponseCode = -2;
                    returnData.ResponseMessenger = "Tên không được chưa ký tự đặc biệt!";
                    return returnData;
                }

                //Bước 3: Check trùng 

                if (students.Count > 0)
                {
                    // var studentExist = students.Where(s => s.Name == requestData.Name).FirstOrDefault();
                    //if (studentExist != null || studentExist.Id > 0)
                    //{
                    //    return -3;
                    //}

                    var studentExist = 0;
                    foreach (var student in students)
                    {
                        if (student.Name == requestData.Name)
                        {
                            studentExist = 1;
                            break;
                        }

                    }

                    if (studentExist > 0)
                    {
                        returnData.ResponseCode = -3;
                        returnData.ResponseMessenger = "Tên đã tồn tại trên hệ thống";
                        return returnData;
                    }

                }

                //Bước 4: Thực hiện Insert 

                students.Add(requestData);


            }
            catch (Exception ex)
            {
                returnData.ResponseCode = -969;
                returnData.ResponseMessenger = ex.Message;
                return returnData;
            }

            returnData.ResponseCode = 1;
            returnData.ResponseMessenger = "Thêm thành công !" + requestData.Name;
            returnData.studentId = Guid.NewGuid();
            return returnData;
        }

       
    }
}
