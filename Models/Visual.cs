using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Cars;
using Models.Interfaces;
using Models.Users;

namespace Models
{
    public class Visual : IUserInfo, IDateTimeInfo, IDepartmentRelationship
    {
        [Key]
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        [ForeignKey("Department")]
        [Column(TypeName = "nvarchar(20)")]
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Company")]
        [Column(TypeName = "nvarchar(20)")]
        public string CompanyCode { get; set; }
        public  Company Company { get; set; }

        //================= Navigation Property =========== 
        public ICollection<User> Users { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<BrandModel> BrandModels { get; set; }
        public ICollection<Car> Cars { get; set; }


    }
}
