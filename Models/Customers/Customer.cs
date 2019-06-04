using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Models.Interfaces;

namespace Models.Customers
{
    public class Customer : IUserInfo, IDateTimeInfo, IDepartmentRelationship, ICompanyRelationship
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public  DateTime? BirthOfDateTime { get; set; }
        public  string Nationality { get; set; }

        public  string Tc { get; set; }
        public  string PassportSerialNumber { get; set; }
        public  string FirstPhone { get; set; }
        public string SecondPhone { get; set; }

        public  string EMail { get; set; }
        public string Address { get; set; }
        public  int YearOfDrivingLicense { get; set; }
        public  string SerialNumberOfDrivingLicense { get; set; }

        public bool IsActive { get; set; } = true;
        public bool InBlackList { get; set; } = false;

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
        public string CompanyCode { get; set; }
        public Company Company { get; set; }
    }
}
