using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Services.Business.Customers;

namespace Services.Controllers
{
    public class CustomerController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(bool isActive = true)
        {
            var list = await CustomerLogic.GetList(GetToken(), GetDepartmentCode(), isActive);
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int customerId)
        {
            var customer = await CustomerLogic.Get(GetToken(), GetDepartmentCode(), customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Models.Customers.Customer customer)
        {
            var isSuccess = await CustomerLogic.Add(GetToken(), customer);
            return Ok(isSuccess);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Models.Customers.Customer customer)
        {
            var isSuccess = await CustomerLogic.Update(GetToken(), customer);
            return Ok(isSuccess);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove([FromBody] int customerId)
        {
            var isSuccess = await CustomerLogic.Remove(GetToken(), customerId);
            return Ok(isSuccess);
        }
    }
}