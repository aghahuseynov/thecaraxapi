using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;

namespace Models.Users
{
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public string EMail { get; set; }
        public bool IsDeleted { get; set; }
        public int? VisualId { get; set; }
        public int UserLevel { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public System.DateTime CreatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public string DepartmentCode { get; set; }
        public string CompanyCode { get; set; }

    }
}
