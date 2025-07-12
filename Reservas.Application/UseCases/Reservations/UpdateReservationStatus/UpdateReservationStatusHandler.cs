using System;
using System.Threading.Tasks;
using Reservas.Domain.Repositories;

namespace Reservas.Application.UseCases.Reservations.UpdateReservationStatus
{
    public class UpdateReservationStatusHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationStatusHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task HandleAsync(UpdateReservationStatusCommand command)
        {
            var reservation = await _reservationRepository.GetByIdAsync(command.ReservationId);
            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            reservation.UpdateStatus(command.NewStatus);
            await _reservationRepository.UpdateAsync(reservation);
        }
    }
}
