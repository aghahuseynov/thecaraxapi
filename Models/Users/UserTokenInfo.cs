using System;
using System.Collections.Generic;
using System.Text;
using Models.Tokens;

namespace Models.Users
{
    public class UserTokenInfo : TokenInfo
    {
        public UserTokenInfo()
        {
        }

        public UserTokenInfo(Guid tokenGuid, int userId, string username, string departmentCode, int level, string email,  DateTime createdDateTime, DateTime endDateTime,string companyCode)
        {
            TokenGuid = tokenGuid;
            UserId = userId;
            Username = username;
            DepartmentCode = departmentCode;
            UserLevel = level;
            Email = email;
            CompanyCode = companyCode;
            CreatedDateTime = createdDateTime;
            TokenEndDateTime = endDateTime.AddDays(1);
        }
    }
    public class TokenResult
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public Guid Token { get; set; }
    }
}
