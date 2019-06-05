using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Users;

namespace Models.Tokens
{
    public class Token
    {
        [Key]
        public Guid TokenGuid { get; set; }

        [Column(TypeName = "datetime")]
        public  DateTime TokenEndDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreateDateTime { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Username { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Department")]
        [Column(TypeName = "nvarchar(20)")]
        public string DepartmentCode { get; set; }
        public  Department Department { get; set; }


        [ForeignKey("CompanyCode")]
        [Column(TypeName = "nvarchar(20)")]
        public string CompanyCode { get; set; }
        public  Company Company { get; set; }

    }
}
