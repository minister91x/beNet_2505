using BE_2505.DataAccess.DAL;
using BE_2505.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.DALImpl
{
    public class DeveloperDALImpl : Employeer, IAttendanceDAL
    {
        public void checkAttendance()
        {
            throw new NotImplementedException();
        }

        public override string working()
        {
            return "coding";
        }
    }
}
