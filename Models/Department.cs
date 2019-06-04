using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Customers;
using Models.Interfaces;
using Models.Users;

namespace Models
{
    public class Department
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? VisualId { get; set; }
        public string CompanyCode { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
