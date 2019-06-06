using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business.Cars;

namespace Services.Controllers
{

    public class CarServiceController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> Get()
        {
            var list = await CarServiceLogic.Get(GetToken(), GetDepartmentCode());
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int carId)
        {
            var list = await CarServiceLogic.Get(GetToken(), GetDepartmentCode(), carId);
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Models.Cars.CarService car)
        {
            var isSuccess = await CarServiceLogic.Add(GetToken(), GetDepartmentCode(), car);
            return Ok(isSuccess);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Models.Cars.CarService car)
        {
            var isSuccess = await CarServiceLogic.Update(GetToken(), GetDepartmentCode(), car);
            return Ok(isSuccess);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int serviceId)
        {
            var isSuccess = await CarServiceLogic.Delete(GetToken(), GetDepartmentCode(), serviceId);
            return Ok(isSuccess);
        }



    }
}