using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Roles;
using Services.Business.Reservations;

namespace Services.Controllers
{
    public class ReservationController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] Models.Reservations.Reservation reservations)
        {
            var isSuccess = await ReservationLogic.Create(GetToken(), reservations);
            return Ok(isSuccess);
        }

        [HttpGet("GetByCarId")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> GetByCarId(int carId)
        {
            var list = await ReservationLogic.GetByCarId(GetToken(), GetDepartmentCode(), carId);
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("GetByCustomer")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var list = await ReservationLogic.GetByCustomerId(GetToken(), GetDepartmentCode(), customerId);
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("GetList")]
        [AuthenticationFilter.AllowAnonymous]
        public async Task<IActionResult> GetList(bool isApproval = false)
        {

            var list = await ReservationLogic.GetList( GetDepartmentCode(), isApproval);
            return Ok(list);
        }

        [HttpPut("Update")]
        [AuthenticationFilter.Authorize(Role.DepartmentOwner)]
        public async Task<IActionResult> Update([FromBody] Models.Reservations.Reservation reservation)
        {
            var isSuccess = await ReservationLogic.Update(GetToken(), reservation);
            return Ok(isSuccess);
        }
    }
}