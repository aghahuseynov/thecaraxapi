using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IUserInfo
    {
         string CreatedBy { get; set; }
         string UpdatedBy { get; set; }
    }
}
