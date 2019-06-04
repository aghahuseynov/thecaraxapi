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
        public  DateTime TokenEndDateTime { get; set; }
        public  DateTime CreateDateTime { get; set; }
        public  string Username { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public  Department Department { get; set; }


        [ForeignKey("CompanyCode")]
        public int CompanyCode { get; set; }
        public  Company Company { get; set; }

    }
}
