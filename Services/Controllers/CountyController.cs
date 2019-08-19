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
        public async Task<IActionResult> Get()
        {
            var result = await CountyLogic.Get();
            return Ok(result);
        }
    }
}