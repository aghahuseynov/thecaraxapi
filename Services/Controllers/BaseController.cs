using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Services.Controllers
{
    [Route("/api/{departmentCode}/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public abstract class BaseController : ControllerBase
    {
        public const string DepartmentCode = "departmentcode";
        public static string Username = "username";
        public const string Token = "token";
        public const string AccessToken = "accesstoken";

        protected BaseController()
        {
            if (QueryParameters == null)
            {
                QueryParameters = new QueryParameters();
            }
        }
        protected bool CheckMemberUserIsNotAuthorized(string id)
        {
            var userInfo = AuthenticationLogic.CheckTokenInfo(GetToken());
            if (userInfo.Username.IsNumeric())
            {
                return userInfo.Username != id;
            }
            return false;
        }

        [NonAction]
        public string GetDepartmentCode()
        {
            string requestMallCode = null;

            if (ControllerContext
                .RouteData
                .Values
                .ContainsKey(DepartmentCode))
            {
                requestMallCode = ControllerContext
                    .RouteData
                    .Values[DepartmentCode] as string;
            }

            requestMallCode = requestMallCode.Replace("\\", string.Empty).Replace("\"", string.Empty);
            requestMallCode = requestMallCode.Replace("\"", string.Empty);

            var identityMallCode = ControllerContext
                ?.HttpContext
                ?.User
                ?.Claims
                ?.FirstOrDefault(c => string.Equals(c.Type, DepartmentCode, StringComparison.CurrentCultureIgnoreCase))
                ?.Value;

            if (!string.IsNullOrEmpty(identityMallCode) && !string.Equals(requestMallCode.Trim(), identityMallCode, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Requested DepartmentCode and Identity DepartmentCode does NOT match");
            }

            return requestMallCode;
        }

        [NonAction]
        public string GetAccessToken()
        {
            return Request.Headers[AccessToken].ToString();
        }


        [NonAction]
        public Guid GetToken()
        {
            var userClaims = ControllerContext
                ?.HttpContext
                ?.User
                ?.Claims.ToList();

            var tokenString = userClaims
                ?.FirstOrDefault(c => string.Equals(c.Type, Token, StringComparison.CurrentCultureIgnoreCase))
                ?.Value;

            if (tokenString == null)
            {
                throw new AuthenticationException("Token can NOT be NULL");
            }

            var identityToken = Guid.Parse(tokenString);

            if (!Request.Headers.ContainsKey(Token))
            {
                if (userClaims.Any(c => string.Equals(c.Type, Username, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return identityToken;
                }
                throw new Exception("Public Token is NOT set");
            }

            if (!Request.Headers.TryGetValue(Token, out var requestTokenStrings))
            {
                throw new Exception("Public Token Value is NOT set");
            }

            var requestTokenString = requestTokenStrings.FirstOrDefault();
            if (requestTokenString is null)
            {
                throw new Exception("Token can NOT be NULL");
            }

            var requestToken = Guid.Parse(requestTokenString);

            if (requestToken != identityToken)
            {
                throw new Exception("Requested Token and Identity Token does NOT match");
            }

            return identityToken;
        }

        public static QueryParameters QueryParameters { get; set; }

    }

    public class QueryParameters
    {
        private static HttpRequest Request => HttpHelper.HttpContext.Request;

        public string GetValue(string key)
        {
            return Request.Query.TryGetValue(key, out var values) ? values.FirstOrDefault() : string.Empty;
        }

        public bool IsValid(string value, int maxLength, int minLength = 1)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= minLength && value.Length <= maxLength;
        }

    }

    public static class HttpHelper
    {
        private static IHttpContextAccessor _accessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;
    }
}
