using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Services.Business.Customers;

namespace Services.Controllers.Public
{
    public class PublicCustomerController : BaseController
    {
        [HttpPut("Create")]
        [AuthenticationFilter.AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] Models.Customers.Customer customer)
        {
            if (!await PublicAuthLogic.CheckAccessToken(GetAccessToken(), GetDepartmentCode()))
            {
                return Unauthorized();
            }
            var isSuccess = await CustomerLogic.Add(customer, GetDepartmentCode());
            return Ok(isSuccess);
        }
    }
}