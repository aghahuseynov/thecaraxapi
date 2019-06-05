using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;

namespace Models.Cars
{
    public class Brand :ISoftDelete,IVisualRelationship
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(35)")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;
        public int? VisualId { get; set; }
        public Visual Visual { get; set; }

        //======== Navigation Property  ===== 

        public ICollection<BrandModel> BrandModels { get; set; }
        public  ICollection<Car> Cars { get; set; }

    }
}
