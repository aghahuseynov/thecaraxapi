using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Address
{
    public class County
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }


        //========== Navigation ===========
        public ICollection<Customers.Customer> Customers { get; set; }

    }
}
