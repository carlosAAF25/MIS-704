using System;
using System.Threading.Tasks;
using Reservas.Domain.Entities;
using Reservas.Domain.Repositories;

namespace Reservas.Application.UseCases.Reservations.GetReservationById
{
    public class GetReservationByIdHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByIdHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> HandleAsync(GetReservationByIdQuery query)
        {
            var reservation = await _reservationRepository.GetByIdAsync(query.ReservationId);
            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            return reservation;
        }
    }
}
