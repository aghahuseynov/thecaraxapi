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
        public async Task<IActionResult> GetDepartment()
        {
            var list = await DepartmentLogic.GetDepartments(GetToken());
            return Ok(list);
        }

        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Department department)
        {
            var list = await DepartmentLogic.Create(GetToken(), department);
            return Ok(list);
        }

        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Models.Department department)
        {
            var list = await DepartmentLogic.Update(GetToken(), GetDepartmentCode(), department);
            return Ok(list);
        }

    }
}