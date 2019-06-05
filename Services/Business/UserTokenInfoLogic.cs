using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using DataAccess;
using Models.Users;
using UserTokenInfo = Models.Users.UserTokenInfo;

namespace Services.Business
{
    public static class UserTokenInfoLogic
    {
        public static UserTokenInfo Get(Guid token)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var singleToken = db.Tokens?.FirstOrDefault(q => q.TokenGuid == token);
                if (singleToken == null)
                {
                    return null;
                }

                var user = db.Users.SingleOrDefault(q =>
                    q.Username == singleToken.Username && q.DepartmentCode == singleToken.DepartmentCode);


                return new Models.Users.UserTokenInfo(tokenGuid:singleToken.TokenGuid,userId:singleToken.UserId,departmentCode:singleToken.DepartmentCode,username:singleToken.Username,level:user.UserLevel,email:user.EMail, createdDateTime:singleToken.CreateDateTime,endDateTime:singleToken.TokenEndDateTime,companyCode:singleToken.CompanyCode);
            }
        }

        public static List<UserTokenInfo> GetTokens(int userId, string userName)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var userTokenInfo = db.UserTokenInfos.Where(q => q.UserId == userId && q.Username == userName).ToList();

                var result = new List<UserTokenInfo>();

                var user = UserLogic.Get(userId);
                var departments = DepartmentLogic.GetAll();
                var userDepartments = UserDepartmentLogic.GetListByUser(userId);

                foreach (var department in departments)
                {
                    var info = userTokenInfo.FirstOrDefault(x => x.DepartmentCode == department.Code);
                    if (info is null) { continue; }

                    if (result.Any(x => x.DepartmentCode == info.DepartmentCode)) { continue; }

                    var userMall = userDepartments.FirstOrDefault(x => x.DepartmentCode == department.Code && x.Username == info.Username);
                    if (userMall is null) { continue; }

                    result.Add(new Models.Users.UserTokenInfo(info.TokenGuid, info.UserId, info.Username, info.DepartmentCode, user.UserLevel, user.EMail, info.CreatedDateTime, info.TokenEndDateTime,info.CompanyCode));
                }

                return result;
            }
        }

        public static bool Update(Guid tokenGuid, DateTime tokenEndDateTime)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var userTokenInfo = db.UserTokenInfos?.FirstOrDefault(q => q.TokenGuid == tokenGuid);
                if (userTokenInfo == null)
                {
                    return false;
                }
                userTokenInfo.TokenEndDateTime = tokenEndDateTime;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Create(Models.Users.UserTokenInfo tokenInfo)
        {
            var userTokenInfo = new Models.Users.UserTokenInfo
            {
                CompanyCode =  tokenInfo.CompanyCode,
                CreatedDateTime =  DateTime.Now,
                DepartmentCode = tokenInfo.DepartmentCode,
                TokenEndDateTime = tokenInfo.TokenEndDateTime,
                TokenGuid = tokenInfo.TokenGuid,
                UserId = tokenInfo.UserId,
                Username =  tokenInfo.Username
            };

            using (var db = new DataAccess.CaraxEntitiy())
            {
                db.UserTokenInfos.Add(userTokenInfo);
               return db.SaveChanges() > 0;
            }
        }
    }
}
