using Reservas.Domain.Entities;
using Reservas.Domain.Repositories;

namespace Reservas.Application.UseCases.Reservations.CreateReservation
{
    public class CreateReservationHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Guid> HandleAsync(CreateReservationCommand command)
        {
            var available = await _reservationRepository.IsSpaceAvailable(
                command.SpaceId,
                command.StartDate,
                command.EndDate
            );

            if (!available)
                throw new InvalidOperationException(
                    "The selected space is not available in the given time range."
                );

            var reservation = new Reservation(
                command.UserId,
                command.SpaceId,
                command.StartDate,
                command.EndDate
            );

            await _reservationRepository.AddAsync(reservation);
            return reservation.Id;
        }
    }
}
