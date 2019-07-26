using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Cars;
using Models.Customers;
using Models.Interfaces;
using Models.Reservations;
using Models.Tokens;
using Models.Users;

namespace Models
{
    public class Department
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string DisplayName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Address { get; set; }

        public int? VisualId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EMail { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string TaxNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TaxAdministration { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string FaxNo { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string InstagramUrl { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string FacebookUrl { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string OfficalEMail { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string PublicSiteUrl { get; set; }


        [ForeignKey("Company")]
        [Column(TypeName = "nvarchar(20)")]
        public string CompanyCode { get; set; }
        public  Company Company { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDateTime { get; set; }


        //=========== Navigation Properties ============ 
        public  ICollection<User> Users { get; set; }
        public ICollection<UserDepartment> UserDepartments { get; set; }
        public ICollection<Token> Tokens { get; set; }
        public ICollection<Visual> Visuals { get; set; }
        public ICollection<UserTokenInfo> UserTokenInfo { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<CarService> CarServices { get; set; }
        public ICollection<Reservations.Reservation> Reservations { get; set; }
        public ICollection<ServicesInReservation> ServicesInReservations { get; set; }

    }
}
