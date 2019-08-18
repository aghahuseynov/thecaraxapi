using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Roles;
using Services.Business;

namespace Services.Controllers
{
    public class CountriesController : BaseController
    {

        [HttpGet]
        [AuthenticationFilter.AllowAnonymous()]
        public async Task<IActionResult> Get()
        {
            var result = await CountriesLogic.Get();
            return Ok(result);
        }
    }
}