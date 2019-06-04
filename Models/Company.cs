using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Customers;
using Models.Interfaces;
using Models.Users;

namespace Models
{
    public class Company : IDateTimeInfo, IUserInfo
    {
        [Key]
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNo { get; set; }
        [ForeignKey("Visual")]
        public int VisualId { get; set; }
        public  Visual Visual { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        //===================== Navigation Property ====================== 

        public ICollection<Department> Departments { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<UserDepartment> UserDepartments { get; set; }



    }
}
