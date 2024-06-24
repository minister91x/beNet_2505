using BE_2505.DataAccess.DAL;
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
