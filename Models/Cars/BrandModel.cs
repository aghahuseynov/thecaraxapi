using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;

namespace Models.Cars
{
    public class BrandModel : ISoftDelete, IVisualRelationship
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public int Year { get; set; }

        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }


        public bool IsDeleted { get; set; }
        public int? VisualId { get; set; }
        public Visual Visual { get; set; }


        //========== Navigation Properties ======= 
        public virtual ICollection<Car> Cars { get; set; }

    }
}
