using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Roles;
using Services.Business.Cars;

namespace Services.Controllers
{
    public class CarController : BaseController
    {
        [HttpGet("Get")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Get(bool isMaintenance=false)
        {
            var list = await CarLogic.GetList(GetToken(), GetDepartmentCode(), isMaintenance);
            return Ok(list);
        }

        [HttpPost("Create")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Create([FromBody]Models.Cars.Car car)
        {
            var isSuccess = await CarLogic.Add(GetToken(), GetDepartmentCode(), car);
            return Ok(isSuccess);
        }

        [HttpPut("Update")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Update(Models.Cars.Car car)
        {
            var isSuccess = await CarLogic.Update(GetToken(), car);
            return Ok(isSuccess);
        }

        [HttpDelete("Delete")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Delete(int carId)
        {
            var isSuccess = await CarLogic.Delete(GetToken(),carId);
            return Ok(isSuccess);
        }

        [HttpPut("BeMaintenance")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> BeMaintenance(int carId, bool maintenance)
        {
            var isSuccess = await CarLogic.BeMaintenance(GetToken(), carId, maintenance);
            return Ok(isSuccess);
        }

        [HttpPut("BeCrash")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> BeCrash(int carId, bool crash)
        {
            var isSuccess = await CarLogic.BeCrash(GetToken(), carId, crash);
            return Ok(isSuccess);
        }
    }
}