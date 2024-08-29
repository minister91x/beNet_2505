using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DBContext
{
    public class BE_25_05DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BE_25_05DbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Product>? product { get; set; }
        public DbSet<Account> account { get; set; }
        public DbSet<Function> function { get; set; }
        public DbSet<Permission> permission { get; set; }
        public DbSet<User_Session> user_session { get; set; }
    }
}
