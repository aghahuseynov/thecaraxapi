using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;

namespace Models
{
    public class Department : IDateTimeInfo, IUserInfo, ICompanyRelationship
    {
        [Key]
        public  string DepartmentCode { get; set; }

        public  string Name { get; set; }
        public  string Address { get; set; }
        public  string Phone { get; set; }

        public string CompanyCode { get; set; }
        public Company Company { get; set; }
        
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
 
    }
}
