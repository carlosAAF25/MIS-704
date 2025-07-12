using System;
using System.Threading.Tasks;
using Reservas.Domain.Repositories;

namespace Reservas.Application.UseCases.Reservations.CancelReservation
{
    public class CancelReservationHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public CancelReservationHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task HandleAsync(CancelReservationCommand command)
        {
            var reservation = await _reservationRepository.GetByIdAsync(command.ReservationId);
            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            reservation.Cancel();
            await _reservationRepository.UpdateAsync(reservation);
        }
    }
}
