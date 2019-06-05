using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;

namespace Models.Users
{
    public class UserDepartment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }

        [ForeignKey("Company")]
        public string CompanyCode { get; set; }
        public Company Company { get; set; }


        [ForeignKey("Department")]
        [Column(TypeName = "nvarchar(20)")]
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
    }
}
