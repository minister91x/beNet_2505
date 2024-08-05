using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Tên không đc trống!")]
        public string? Name { get; set; }
    }
}
