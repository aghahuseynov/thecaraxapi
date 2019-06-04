using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
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
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }

        //================= Navigation Property =========== 
        public ICollection<Department> Departments { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
