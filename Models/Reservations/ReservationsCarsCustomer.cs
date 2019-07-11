using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Reservations
{
    public class ReservationsCarsCustomer
    {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }


        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerFirstPhone { get; set; }


        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string CarPlate { get; set; }
        public string CarEngineCapacity { get; set; }
        public decimal CarPrice { get; set; }



        public DateTime ReservationStartDateTime { get; set; }
        public DateTime ReservationEndDateTime { get; set; }
        public decimal? ReservationPrice { get; set; }
        public int ReservationState { get; set; }

        public string ReservationFuelCount { get; set; }
        public int? ReservationKmStart { get; set; }
        public int? ReservationKmEnd { get; set; }
        public int? ReservationDeposit { get; set; }
        public int? ReservationPaymentType { get; set; }


        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
