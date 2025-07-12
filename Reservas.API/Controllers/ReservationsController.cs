using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Reservations.CancelReservation;
using Reservas.Application.UseCases.Reservations.CreateReservation;
using Reservas.Application.UseCases.Reservations.GetReservations;

namespace Reservas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly CreateReservationHandler _createReservationHandler;
        private readonly GetReservationsHandler _getReservationsHandler;
        private readonly CancelReservationHandler _cancelReservationHandler;

        public ReservationsController(
            CreateReservationHandler createReservationHandler,
            GetReservationsHandler getReservationsHandler,
            CancelReservationHandler cancelReservationHandler
        )
        {
            _createReservationHandler = createReservationHandler;
            _getReservationsHandler = getReservationsHandler;
            _cancelReservationHandler = cancelReservationHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(
            [FromBody] CreateReservationCommand command
        )
        {
            try
            {
                var reservationId = await _createReservationHandler.HandleAsync(command);
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

        [HttpGet("{id}")]
        public IActionResult GetReservationById(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations([FromQuery] Guid? userId)
        {
            var query = new GetReservationsQuery { UserId = userId };
            var reservations = await _getReservationsHandler.HandleAsync(query);
            return Ok(reservations);
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelReservation(
            [FromBody] CancelReservationCommand command
        )
        {
            try
            {
                await _cancelReservationHandler.HandleAsync(command);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
