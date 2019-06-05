using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Interfaces;

namespace Models.Cars
{
    public class CarService:IDepartmentRelationship,IUserInfo,ICompanyRelationship,IDateTimeInfo
    {
        [Key]
        public  int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public int Name { get; set; }

        public decimal Price { get; set; }

        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CompanyCode { get; set; }
        public Company Company { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }


        //========== Navigation Properties ========== 
        public ICollection<CarInService> CarInServices { get; set; }

    }
}
