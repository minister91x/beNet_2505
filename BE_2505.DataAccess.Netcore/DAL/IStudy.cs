using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DAL
{
    public interface IStudy
    {
        void HocToan();
    }

    public interface IStudyIt
    {
        void HocCoding();
    }
    public interface IStudyEconomic
    {
        void HocKinhKe();
    }
    public interface IStudyDialy
    {
        void HocDiaLy();
    }
}
