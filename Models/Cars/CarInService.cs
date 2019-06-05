using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Models.Cars
{
    public class CarInService
    {
        [Key]
        public  int Id { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [ForeignKey("CarService")]
        public int CarServiceId { get; set; }
        public CarService CarService { get; set; }

    }
}
