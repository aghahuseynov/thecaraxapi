using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Models.Reservations;
using Services.Business.Reservations;

namespace Services.Controllers
{
    public class ServicesInReservationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] Models.Reservations.ServicesInReservation servicesInReservation)
        {
            var isSuccess = await ServicesInReservationLogic.Create(GetToken(), GetDepartmentCode(), servicesInReservation);
            return Ok(isSuccess);
        }
    }
}
