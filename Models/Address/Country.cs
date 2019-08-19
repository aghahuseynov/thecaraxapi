using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Address
{
    public class Country
    {
        [Key]
        [Column(TypeName = "nvarchar(10)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }


        //==================== Navigation Property ============== 
        public ICollection<City> Cities { get; set; }
        public ICollection<Customers.Customer> Customers { get; set; }


    }
}
