using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Address
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public Country Country { get; set; }

        //==================== Navigation Property ============== 
        public ICollection<County> Counties { get; set; }
    }
}
