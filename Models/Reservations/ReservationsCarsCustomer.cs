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

    }
}
