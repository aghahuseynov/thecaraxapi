using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Address;
using Models.Interfaces;

namespace Models.Customers
{
    public class Customer : IUserInfo, IDateTimeInfo, IDepartmentRelationship, ICompanyRelationship, ISoftDelete
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Surname { get; set; }

        public int? Gender { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? BirthOfDateTime { get; set; }

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

        [Column(TypeName = "datetime")]
        public DateTime? LicenseYear { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string SerialNumberOfDrivingLicense { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsAdditionalDriver { get; set; } = false;

        public bool InBlackList { get; set; } = false;
        public int? LocationSite { get; set; }

        public string Profession { get; set; }
        public int? BloodGroup { get; set; }
        public string OldCity { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public Country Country { get; set; }



        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
        public string CompanyCode { get; set; }
        public Company Company { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string NameOfMother { get; set; }
        public string NameOfFather { get; set; }
        public string DrivingClasses { get; set; }



        //        ========== Navigation Properties ========= 
        public ICollection<Reservations.Reservation> Reservations { get; set; }
    }
}
