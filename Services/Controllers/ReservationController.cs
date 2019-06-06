using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class ReservationController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Reservations.Reservation reservations)
        {
            return Ok();
        }

        [HttpGet("GetByReservation")]
        public async Task<IActionResult> GetByReservation(int carId)
        {
            return Ok();
        }
        
        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            return Ok();
        }
        
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok();
        }

        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(int statusId)
        {
            return Ok();
        }
        
        
        
        
    }
}