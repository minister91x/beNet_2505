using BE_2505.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.DAL
{
    public interface IStudentDAL
    {
        StudentInsert_ResponseData Student_Insert(Student requestData);

        List<Student> Baocao();
    }
}
