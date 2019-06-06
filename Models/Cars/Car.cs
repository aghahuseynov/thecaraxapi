using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using System.Text;
using Models.Interfaces;

namespace Models.Cars
{
    public class Car : IDateTimeInfo, IUserInfo, IVisualRelationship, ISoftDelete, ICompanyRelationship, IDepartmentRelationship
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("BrandModel")]
        public int BrandModelId { get; set; }
        public BrandModel BrandModel { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Plate { get; set; }


        public int CaseType { get; set; }

        public int FuelType { get; set; }

        public int GearType { get; set; }

        public string Km { get; set; }

        public string EngineCapacity { get; set; }

        public int NumberOfDoors { get; set; }

        public decimal Price { get; set; }

        public int MinDriverLicense { get; set; }

        public bool Maintenance { get; set; } = false;

        public bool Crash { get; set; } = false;

        public string Color { get; set; }

        public decimal? Deposit { get; set; }

        public int? Classes { get; set; }


        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? VisualId { get; set; }
        public Visual Visual { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CompanyCode { get; set; }
        public Company Company { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }


        // ================ Navigation Properties ====================
        public ICollection<CarInService> CarInServices { get; set; }
        public ICollection<CarProperty> CarProperties { get; set; }
        public ICollection<Reservations.Reservation> Reservations { get; set; }


    }
}
