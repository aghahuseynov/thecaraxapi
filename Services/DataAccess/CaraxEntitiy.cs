using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models.Reservations;

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
        public DbSet<Models.Tokens.Token> Tokens { get; set; }
        public DbSet<Models.Cars.BrandModel> BrandModels { get; set; }
        public DbSet<Models.Cars.Brand> Brands { get; set; }

        public DbSet<Models.Cars.CarProperty> CarProperties { get; set; }
        public DbSet<Models.Cars.Car> Cars { get; set; }
        public DbSet<Models.Cars.CarInService> CarInServices { get; set; }
        public DbSet<Models.Cars.CarService> CarServices { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }
        
        public DbSet<ServicesInReservation> ServicesInReservations { get; set; }

        public DbSet<Models.Address.Country> Countries { get; set; }
        public DbSet<Models.Address.City> Cities { get; set; }
        public DbSet<Models.Address.County> Counties { get; set; }

    }
}
