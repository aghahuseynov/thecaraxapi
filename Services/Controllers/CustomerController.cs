using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Roles;
using Services.Business;
using Services.Business.Customers;

namespace Services.Controllers
{
    public class CustomerController : BaseController
    {
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(bool isActive = true)
        {
            var list = await CustomerLogic.GetList(GetToken(), GetDepartmentCode(), isActive);
            return Ok(list);
        }

        [HttpGet("Get")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Get(int customerId)
        {
            var customer = await CustomerLogic.Get(GetToken(), GetDepartmentCode(), customerId);
            return Ok(customer);
        }


        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] Models.Customers.Customer customer)
        {
            var isSuccess = await CustomerLogic.Add(GetToken(), customer);
            return Ok(isSuccess);
        }

        [HttpPut("Update")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Update([FromBody] Models.Customers.Customer customer)
        {
            var isSuccess = await CustomerLogic.Update(GetToken(), customer);
            return Ok(isSuccess);
        }

        [HttpDelete("Remove")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Remove([FromBody] int customerId)
        {
            var isSuccess = await CustomerLogic.Remove(GetToken(), customerId);
            return Ok(isSuccess);
        }
    }
}