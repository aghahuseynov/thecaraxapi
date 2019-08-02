using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Services.Business.Cars;

namespace Services.Controllers.Public
{
    public class PublicCarController : BaseController
    {
        [HttpGet("Get")]
        [AuthenticationFilter.AllowAnonymous]
        public async Task<IActionResult> Get(DateTime beginDateTime, DateTime endDateTime)
        {
            if (!await PublicAuthLogic.CheckAccessToken(GetAccessToken(), GetDepartmentCode()))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid || beginDateTime.Date < DateTime.Now)
            {
               return BadRequest("Parametreler uyuşmuyor");
            }

            var list = await CarLogic.AvailableCar(GetDepartmentCode(), beginDateTime, endDateTime);
            return Ok(list);
        }
    }
}