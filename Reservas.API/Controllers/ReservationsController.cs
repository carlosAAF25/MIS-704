using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Reservations.CancelReservation;
using Reservas.Application.UseCases.Reservations.CreateReservation;
using Reservas.Application.UseCases.Reservations.GetReservationById;
using Reservas.Application.UseCases.Reservations.GetReservations;
using Reservas.Application.UseCases.Reservations.UpdateReservationStatus;

namespace Reservas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly CreateReservationHandler _createReservationHandler;
        private readonly GetReservationsHandler _getReservationsHandler;
        private readonly CancelReservationHandler _cancelReservationHandler;
        private readonly UpdateReservationStatusHandler _updateReservationStatusHandler;
        private readonly GetReservationByIdHandler _getReservationByIdHandler;

        public ReservationsController(
            CreateReservationHandler createHandler,
            GetReservationsHandler getHandler,
            CancelReservationHandler cancelHandler,
            UpdateReservationStatusHandler updateStatusHandler,
            GetReservationByIdHandler getByIdHandler
        )
        {
            _createReservationHandler = createHandler;
            _getReservationsHandler = getHandler;
            _cancelReservationHandler = cancelHandler;
            _updateReservationStatusHandler = updateStatusHandler;
            _getReservationByIdHandler = getByIdHandler;
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

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(
            [FromBody] UpdateReservationStatusCommand command
        )
        {
            try
            {
                await _updateReservationStatusHandler.HandleAsync(command);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(Guid id)
        {
            try
            {
                var query = new GetReservationByIdQuery(id);
                var reservation = await _getReservationByIdHandler.HandleAsync(query);
                return Ok(reservation);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
