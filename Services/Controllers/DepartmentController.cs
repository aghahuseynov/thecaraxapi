using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Roles;

namespace Services.Controllers
{
    public class DepartmentController : BaseController
    {
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        [HttpGet]
        public IActionResult GetDepartment()
        {
            var list =  DepartmentLogic.GetDepartments(GetToken());
            return Ok(list);
        }

    }
}