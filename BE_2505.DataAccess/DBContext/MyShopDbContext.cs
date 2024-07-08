using BE_2505.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.DBContext
{
    public class MyShopDbContext: DbContext
    {
        public MyShopDbContext() : base("name=MyConnectionString")
        {
        }
        public virtual DbSet<Student> student { get; set; }

    }
}
