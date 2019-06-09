using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Tokens;

namespace Models.Users
{
    public class UserTokenInfo
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "nvarchar(50)")]
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

        public UserTokenInfo()
        {
        }

        public UserTokenInfo(Guid tokenGuid, int userId, string username, string departmentCode, int level, string email, DateTime createdDateTime, DateTime endDateTime, string companyCode)
        {
            TokenGuid = tokenGuid;
            UserId = userId;
            Username = username;
            DepartmentCode = departmentCode;
            UserLevel = level;
            Email = email;
            CompanyCode = companyCode;
            CreatedDateTime = createdDateTime;
            TokenEndDateTime = endDateTime.AddDays(1);
        }
    }
    public class TokenResult
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public Guid Token { get; set; }
    }
}
