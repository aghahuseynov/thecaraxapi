using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Cars;
using Models.Customers;
using Models.Interfaces;
using Models.Tokens;
using Models.Users;

namespace Models
{
    public class Company : IDateTimeInfo, IUserInfo
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TaxNo { get; set; }

        public int? VisualId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDateTime { get; set; }

        //===================== Navigation Property ====================== 

        public ICollection<Department> Departments { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<UserDepartment> UserDepartments { get; set; }
        public ICollection<Token> Tokens { get; set; }

        public ICollection<Visual> Visuals { get; set; }
        public  ICollection<UserTokenInfo> UserTokenInfo { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<CarService> CarServices { get; set; }

    }
}
