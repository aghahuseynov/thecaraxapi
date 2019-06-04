using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Tokens
{
    public class TokenInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public Guid TokenGuid { get; set; }
        public DateTime TokenEndDateTime { get; set; }
        public string DepartmentCode { get; set; }
        public string CompanyCode { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int UserLevel { get; set; }
        public string Email { get; set; }
    }
}
