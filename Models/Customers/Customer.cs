using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;

namespace Models.Customers
{
    public class Customer : IUserInfo, IDateTimeInfo, IDepartmentRelationship, ICompanyRelationship,ISoftDelete
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Surname { get; set; }

        public int? Gender { get; set; }

        [Column(TypeName = "datetime")]
        public  DateTime? BirthOfDateTime { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string Nationality { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string Tc { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string PassportSerialNumber { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string FirstPhone { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string SecondPhone { get; set; }

        [Column(TypeName = "nvarchar(120)")]
        public string EMail { get; set; }

        [Column(TypeName = "nvarchar(120)")]
        public string Address { get; set; }

        public  int YearOfDrivingLicense { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string SerialNumberOfDrivingLicense { get; set; }

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
        public bool IsDeleted { get; set; } = false;
    }
}
