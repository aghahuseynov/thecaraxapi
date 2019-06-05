using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Customers;
using Models.Interfaces;
using Models.Tokens;
using Models.Users;

namespace Models
{
    public class Department
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; }

        public int? VisualId { get; set; }

        [ForeignKey("Company")]
        [Column(TypeName = "nvarchar(20)")]
        public string CompanyCode { get; set; }
        public  Company Company { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDateTime { get; set; }


        //=========== Navigation Properties ============ 
        public  ICollection<User> Users { get; set; }
        public ICollection<UserDepartment> UserDepartments { get; set; }
        public ICollection<Token> Tokens { get; set; }
        public ICollection<Visual> Visuals { get; set; }
        public ICollection<UserTokenInfo> UserTokenInfo { get; set; }



    }
}
