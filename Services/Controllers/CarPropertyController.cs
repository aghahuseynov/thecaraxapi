using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business.Cars;

namespace Services.Controllers
{
    public class CarPropertyController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(int carId)
        {
            var list = await CarPropertyLogic.Get(GetToken(), carId);
            if (!list.Any())
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Cars.CarProperty property)
        {
            var isSuccess = await CarPropertyLogic.Create(GetToken(), property);
            return Ok(isSuccess);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Models.Cars.CarProperty property)
        {
            var isSuccess = await CarPropertyLogic.Update(GetToken(), property);
            return Ok(isSuccess);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int propertyId)
        {
            var isSuccess = await CarPropertyLogic.Delete(GetToken(), propertyId);
            return Ok(isSuccess);
        }
    }
}