using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;

namespace Services.Controllers
{
    public class CityController : BaseController
    {

        [HttpGet]
        [AuthenticationFilter.AllowAnonymous()]
        public async Task<IActionResult> Get(string code)
        {
            var result = await CityLogic.GetByCode(code?.ToUpper());
            return Ok(result);
        }

    }
}