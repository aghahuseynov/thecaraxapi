using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Models.Roles;
using Models.Tokens;
using Models.Users;

namespace Services
{
    public class AuthenticationFilter
    {
        public class AuthorizeAttribute : TypeFilterAttribute
        {
            public AuthorizeAttribute(string minimumRole) : base(typeof(AuthorizeActionFilter))
            {
                Arguments = new object[] { minimumRole };
            }
            public AuthorizeAttribute() : base(typeof(AuthorizeActionFilter))
            {
                Arguments = new object[] { Role.Employee };
            }
        }

        public class AllowAnonymousAttribute : TypeFilterAttribute
        {
            public AllowAnonymousAttribute() : base(typeof(AuthorizeActionFilter))
            {
                Arguments = new object[] { nameof(AllowAnonymousAttribute) };
            }
        }

        public class PublicTokenAttribute : TypeFilterAttribute
        {
            public PublicTokenAttribute() : base(typeof(AuthorizeActionFilter))
            {
                Arguments = new object[] { nameof(PublicTokenAttribute) };
            }
        }

        public class AuthorizeActionFilter : IAsyncActionFilter
        {
            private readonly string _value;

            public AuthorizeActionFilter(string value)
            {
                _value = value;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
            {
                if (actionContext.HttpContext.Request.Method == HttpMethod.Options.ToString())
                {
                    return;
                }

                if (_value.Equals(nameof(AllowAnonymousAttribute)))
                {
                    await next();
                    return;
                }

                IList<string> tokenValues = null;

                var isPublicTokenSet = _value.Equals(nameof(PublicTokenAttribute));

                if (!actionContext.HttpContext.Request.Headers.ContainsKey("token"))
                {
                    if (!isPublicTokenSet)
                    {
                        actionContext.Result = new UnauthorizedResult();
                        return;
                    }
                }
                else if (actionContext.HttpContext.Request.Headers.TryGetValue("token", out var tokenStringValues) && !tokenStringValues.IsNullOrEmpty())
                {
                    tokenValues = tokenStringValues.ToList();
                }

                if (!Guid.TryParse(tokenValues?.FirstOrDefault()?.Trim() ?? string.Empty, out var tokenGuid))
                {
                    actionContext.Result = new UnauthorizedResult();
                    return;
                }

                var userTokenInfo = AuthenticationLogic.CheckTokenInfo(tokenGuid);

                string userLevel = "";
                if ((int)Enums.UserLevel.Customer == userTokenInfo.UserLevel)
                {
                    userLevel = Enums.UserLevel.Customer.ToString();
                }

                else if ((int)Enums.UserLevel.CompanyOwner == userTokenInfo.UserLevel)
                {
                    userLevel = Enums.UserLevel.CompanyOwner.ToString();
                }

                else if ((int)Enums.UserLevel.DepartmentOwner == userTokenInfo.UserLevel)
                {
                    userLevel = Enums.UserLevel.DepartmentOwner.ToString();
                }

                else if ((int)Enums.UserLevel.SystemOwner == userTokenInfo.UserLevel)
                {
                    userLevel = Enums.UserLevel.SystemOwner.ToString();
                }

                if (!_value.Contains(userLevel))
                {
                    actionContext.Result = new ForbidResult();
                    return;
                }



                SetIdentities(actionContext, userTokenInfo);

                await next();
            }

            private static void SetIdentities(ActionContext actionContext, UserTokenInfo userTokenInfo)
            {
                if (userTokenInfo == null)
                {
                    return;
                }

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userTokenInfo.Username),
                new Claim(ClaimTypes.Role, userTokenInfo.UserLevel.ToString()),

                new Claim("username", userTokenInfo.Username),
                new Claim("departmentcode", userTokenInfo.DepartmentCode),
                new Claim("token", userTokenInfo.TokenGuid.ToString())
            };

                var identity = new ClaimsIdentity(claims, "token");
                var principal = new ClaimsPrincipal(identity);

                actionContext.HttpContext.User.AddIdentity(identity);
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}
