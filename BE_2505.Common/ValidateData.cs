using ConsoleApp_NetFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public class ValidateData
    {
        public bool CheckIputData(string inpustring)
        {
            if (string.IsNullOrEmpty(inpustring))
            {
                return false;
            }

          
            return true;
        }

        public  bool CheckXSSInput(string input)
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

    }
}
