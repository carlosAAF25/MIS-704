using System;

namespace Reservas.Application.UseCases.Reservations.GetReservationById
{
    public class GetReservationByIdQuery
    {
        public Guid ReservationId { get; set; }

        public GetReservationByIdQuery(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
