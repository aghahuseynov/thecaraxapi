using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Roles
{
    public class Role
    {
        public const string SystemOwner = "SystemOwner";

        public const string CompanyOwner = "CompanyOwner, SystemOwner";

        public const string DepartmentOwner = "SystemOwner, CompanyOwner, DepartmentOwner";

        public const string Employee = "SystemOwner, CompanyOwner, DepartmentOwner,Employee";
    }
}
