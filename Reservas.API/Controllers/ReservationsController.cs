using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Reservations.CreateReservation;

namespace Reservas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly CreateReservationHandler _handler;

        public ReservationsController(CreateReservationHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(
            [FromBody] CreateReservationCommand command
        )
        {
            try
            {
                var reservationId = await _handler.HandleAsync(command);
                return CreatedAtAction(
                    nameof(GetReservationById),
                    new { id = reservationId },
                    reservationId
                );
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        // Optional: implement GetReservationById for CreatedAtAction to work
        [HttpGet("{id}")]
        public IActionResult GetReservationById(Guid id)
        {
            // Implementation pending
            return Ok();
        }
    }
}
