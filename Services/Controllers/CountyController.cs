using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;

namespace Services.Controllers
{

    public class CountyController : BaseController
    {

        [HttpGet]
        [AuthenticationFilter.AllowAnonymous()]
        public async Task<IActionResult> Get(int cityId)
        {
            var result = await CountyLogic.Get(cityId);
            return Ok(result);
        }
    }
}