using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Roles;
using Services.Business;
using Services.Business.Cars;
using Services.Business.Reservations;

namespace Services.Controllers.Public
{
    public class PublicReservationController : BaseController
    {
        [HttpGet("Create")]
        [AuthenticationFilter.AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] Models.Reservations.Reservation reservations)
        {
            if (!await PublicAuthLogic.CheckAccessToken(GetAccessToken(),GetDepartmentCode()))
            {
                return Unauthorized();
            }

            var list = await ReservationLogic.PublicCreate(reservations, GetDepartmentCode());
            return Ok(list);
        }
    }
}