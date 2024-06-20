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
    }
}

