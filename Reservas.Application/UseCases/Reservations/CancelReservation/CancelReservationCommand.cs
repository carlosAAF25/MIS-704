using System;

namespace Reservas.Application.UseCases.Reservations.CancelReservation
{
    public class CancelReservationCommand
    {
        public Guid ReservationId { get; set; }
    }
}
