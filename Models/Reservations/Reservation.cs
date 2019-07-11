using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Cars;
using Models.Interfaces;

namespace Models.Reservations
{
    public class Reservation : IDateTimeInfo, IUserInfo, IDepartmentRelationship, ICompanyRelationship, ISoftDelete
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(120)")]
        public string DeliveryLocation { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime BeginDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EndDateTime { get; set; }
        public int ReservationStatus { get; set; } = (int)Enums.ReservationTypes.Pre;

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customers.Customer Customer { get; set; }

        public bool IsApproval { get; set; } = false;

        public decimal? Price { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int? PaymentType { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string FuelCount { get; set; }
        public int? KmStart { get; set; }
        public int? KmEnd { get; set; }
        public int Deposit { get; set; }




        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
        public string CompanyCode { get; set; }
        public Company Company { get; set; }
        public bool IsDeleted { get; set; } = false;

        //        ====== Navigation Properties ==== 


        public ICollection<ServicesInReservation> ServicesInReservations { get; set; }
    }
}