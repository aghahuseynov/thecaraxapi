using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CaraxEntitiy : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            var connection = "Data Source=157.230.24.97;User ID=sa;Password=aga4539566A;Initial Catalog=TheCaraxDb;app=Services";
            optionBuilder.UseSqlServer(connection);
        }

        public DbSet<Models.Company> Companies { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Users.User> Users { get; set; }
        public DbSet<Models.Users.UserTokenInfo> UserTokenInfos { get; set; }
        public DbSet<Models.Users.UserDepartment> UserDepartments { get; set; }
        public DbSet<Models.Visual> Visuals { get; set; }
        public DbSet<Models.Customers.Customer> Customers { get; set; }
        public  DbSet<Models.Tokens.Token> Tokens { get; set; }

    }
}
