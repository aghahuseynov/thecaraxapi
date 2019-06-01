using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Interfaces
{
    public interface ICompanyRelationship
    {

        [ForeignKey("Company")]
        string CompanyCode { get; set; }
        Company Company { get; set; }

    }
}
