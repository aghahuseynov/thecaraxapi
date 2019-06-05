using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;
using Models.Tokens;

namespace Models.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Surname { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        public string EMail { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Visual")]
        public int? VisualId { get; set; }
        public  Visual Visual { get; set; }

        [Column(TypeName = "int")]
        public int UserLevel { get; set; }

        [Column(TypeName = "datetime")]
        public System.DateTime CreatedDateTime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDateTime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [ForeignKey("Department")]
        [Column(TypeName = "nvarchar(20)")]
        public string DepartmentCode { get; set; }
        public  Department Department { get; set; }

        [ForeignKey("Company")]
        [Column(TypeName = "nvarchar(20)")]
        public string CompanyCode { get; set; }
        public Company Company { get; set; }

        [Column(TypeName = "binary(64)")]
        public byte[] PasswordHash { get; set; }

        [Column(TypeName = "binary(64)")]
        public byte[] PasswordSalt { get; set; }

        //=========== Navigation Properties ======== 

        public  ICollection<UserDepartment> UserDepartments { get; set; }
        public ICollection<Token> Tokens { get; set; }

        public  ICollection<UserTokenInfo> UserTokenInfos { get; set; }


    }
}
