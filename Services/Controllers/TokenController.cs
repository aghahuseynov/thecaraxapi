using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    public class TokenController : BaseController
    {
        [HttpGet("Get")]
        [AllowAnonymous]
        public IActionResult Get(string departmentCode, string username, string password)
        {
            if (!QueryParameters.IsValid(departmentCode, 10) || !QueryParameters.IsValid(username, 50) || string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }
            try
            {
                var tokenResult = AuthenticationLogic.GetToken(username, password, departmentCode);
                var token = tokenResult.Token;
                return Ok(token);
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
