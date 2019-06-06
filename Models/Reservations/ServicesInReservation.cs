using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Cars;
using Models.Interfaces;

namespace Models.Reservations
{
    public class ServicesInReservation : IDateTimeInfo,IUserInfo,IDepartmentRelationship,ICompanyRelationship
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public  Reservation Reservation { get; set; }
        
        [ForeignKey("CarService")]
        public  int CarSericeId { get; set; }
        public  CarService CarService { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
        public string CompanyCode { get; set; }
        public Company Company { get; set; }
    }
}