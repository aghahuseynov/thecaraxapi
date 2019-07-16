using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using Models.Tokens;
using Models.Users;
using Services;
using Services.Business;

namespace Business
{
    public class AuthenticationLogic
    {
        public static readonly ConcurrentDictionary<Guid, UserTokenInfo> Tokens = new ConcurrentDictionary<Guid, UserTokenInfo>();

        public static UserTokenInfo CheckTokenInfo(Guid tokenGuid)
        {
            return CheckTokenInfo(tokenGuid.ToString());
        }
        public static UserTokenInfo CheckTokenInfo(string tokenGuid)
        {
            var token = Guid.Parse(string.Concat(tokenGuid.ToCharArray().Where(x => x != 8203)));

            if (!Tokens.TryGetValue(token, out var userInfo))
            {
                userInfo = UserTokenInfoLogic.Get(token);

                if (userInfo == null) { throw new AuthenticationException("Token not found."); }

                Tokens.AddOrUpdate(token, userInfo);
            }

            userInfo.TokenEndDateTime = UserTokenInfoLogic.Get(token).TokenEndDateTime;

            try
            {
                if (userInfo.TokenEndDateTime >= DateTime.Now)
                {
                    return userInfo;
                }

                if (Tokens.TryRemove(token, out userInfo))
                {
                    UserTokenInfoLogic.Delete(token); // delete token

                    throw new TimeoutException("Authentication token expired.");
                }
            }
            catch (TimeoutException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new AuthenticationException("Token not found.");
            }

            return userInfo;
        }


        public static TokenResult GetToken(string username, string password, string departmentCode)
        {
            return GetUserTokenGuid(username, password, departmentCode)
                .FirstOrDefault(x => x.DepartmentCode == departmentCode);
        }

        private static List<Models.Users.TokenResult> GetUserTokenGuid(string username, string password, string departmentCode)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                var userDepartments = db.UserDepartments.Where(q => q.Username == username && q.DepartmentCode == departmentCode).ToList();

                if (!userDepartments.Any())
                {
                    throw new AuthenticationException();
                }

                var userId = userDepartments.First().UserId;

                var user = db.Users.FirstOrDefault(q => q.Id == userId);

                if (!user.IsActive)
                {
                    throw new AuthenticationException("This user is not active.");
                }
                // checkpassword
                if (!password.GetSHA512(user.PasswordSalt).SequenceEqual(user.PasswordHash))
                {
                    throw new AuthenticationException();
                }

                var departments = db.Departments.ToList();

                var tokens = new List<TokenResult>();

                var dbTokens = UserTokenInfoLogic.GetTokens(userId, username);

                var dateTime = DateTime.Now;

                foreach (var info in dbTokens)
                {
                    info.TokenEndDateTime = dateTime.AddDays(1);
                    Tokens.AddOrUpdate(info.TokenGuid, info);
                    var departmentFirst = departments.FirstOrDefault(x => x.Code == info.DepartmentCode);
                    tokens.Add(new TokenResult { DepartmentCode = info.DepartmentCode, DepartmentName = departmentFirst?.Name, Token = info.TokenGuid });
                }

                Task.Factory.StartNew(() =>
                {
                    foreach (var info in dbTokens)
                    {
                        UserTokenInfoLogic.Update(info.TokenGuid, info.TokenEndDateTime);
                    }
                });

                var userDepartmentWithByUser = UserDepartmentLogic.GetListByUser(userId);
                if (userDepartmentWithByUser.Count > dbTokens.Count)
                {
                    foreach (var department in userDepartmentWithByUser.Where(x => dbTokens.All(y => y.DepartmentCode != x.DepartmentCode)))
                    {
                        var departmentFirst = departments.FirstOrDefault(x => x.Code == department.DepartmentCode);

                        // set token
                        var tokenGuid = Guid.NewGuid();
                        var tokenInfo = new Models.Users.UserTokenInfo(tokenGuid, user.Id, user.Username, department.DepartmentCode, user.UserLevel, user.EMail, dateTime, dateTime.AddDays(1), user.CompanyCode);

                        // add to db
                        UserTokenInfoLogic.Create(tokenInfo);
                        Models.Tokens.Token tk = new Token
                        {
                            CompanyCode =  tokenInfo.CompanyCode,
                            CreateDateTime = tokenInfo.CreatedDateTime,
                            DepartmentCode =  tokenInfo.DepartmentCode,
                            TokenEndDateTime = tokenInfo.TokenEndDateTime,
                            TokenGuid = tokenInfo.TokenGuid,
                            UserId =  tokenInfo.UserId,
                            Username = tokenInfo.Username
                        };
                        db.Tokens.Add(tk);
                        db.SaveChanges();
                        
                        // add yo dictionary
                        Tokens.AddOrUpdate(tokenGuid, tokenInfo);

                        tokens.Add(new TokenResult { DepartmentCode = department.DepartmentCode, DepartmentName = departmentFirst?.Name, Token = tokenGuid });
                    }
                }

                return tokens;
            }

        }

    }
}
