using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Interfaces
{
    public interface IDepartmentRelationship
    {
        [ForeignKey("Department")]
        string DepartmentCode { get; set; }
        Department Department { get; set; }
    }
}
