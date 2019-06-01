using System;
using System.ComponentModel.DataAnnotations;
using Models.Interfaces;

namespace Models
{
    public class Company: IDateTimeInfo,IUserInfo
    {
        [Key]
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNo { get; set; }
        public  int LogoId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
