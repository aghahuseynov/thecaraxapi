using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Tokens
{
    public class TokenInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        [Key]
        public Guid TokenGuid { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TokenEndDateTime { get; set; }


        [ForeignKey("Department")]
        [Column(TypeName = "nvarchar(20)")]
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Company")]
        [Column(TypeName = "nvarchar(20)")]
        public string CompanyCode { get; set; }
        public Company Company { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "int")]
        public int UserLevel { get; set; }

        [Column(TypeName = "nvarchar(120)")]
        public string Email { get; set; }
    }
}
