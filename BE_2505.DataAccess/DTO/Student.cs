using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.DTO
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        private int GPA { get; set; } = 4;
        // private string FullName { get; set; } = "MR QUÂN";

        private string FirstName { get; set; } = "MR";
        private string LastName { get; set; } = "QUÂN";

        //public void SetFullName(string _firstName,string _lastName)
        //{
        //    FirstName = _firstName;
        //}

        public string GetFullName()
        {
            return FirstName + LastName;
        }
    }
}

