using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Roles;
using Services.Business.Cars;

namespace Services.Controllers
{
    public class CarInServiceController : BaseController
    {
        [HttpPost]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Create([FromBody] Models.Cars.CarInService carInService)
        {
            var isSuccess = await CarInServiceLogic.Create(GetToken(), GetDepartmentCode(), carInService);
            return Ok(isSuccess);
        }

        [HttpDelete]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Delete(int carId, int serviceId)
        {
            var isSuccess = await CarInServiceLogic.Remove(GetToken(), GetDepartmentCode(), carId,serviceId);
            return Ok(isSuccess);
        }
    }
}