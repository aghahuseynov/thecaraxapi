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

        public int Id { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public string CompanyCode { get; set; }
        public string DepartmentCode { get; set; }

    }
}
