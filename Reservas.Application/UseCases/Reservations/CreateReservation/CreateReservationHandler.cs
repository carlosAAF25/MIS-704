using Reservas.Domain.Repositories;
using Reservas.Domain.Services;

namespace Reservas.Application.UseCases.Reservations.CreateReservation
{
    public class CreateReservationHandler
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ISpaceRepository _spaceRepository;
        private readonly IUserRepository _userRepository;

        private readonly INotificationService _notificationService;

        public CreateReservationHandler(
            IReservationRepository reservationRepository,
            ISpaceRepository spaceRepository,
            IUserRepository userRepository,
            INotificationService notificationService
        )
        {
            _reservationRepository = reservationRepository;
            _spaceRepository = spaceRepository;
            _userRepository = userRepository;
            _notificationService = notificationService;
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

            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user != null)
            {
                var space = await _spaceRepository.GetByIdAsync(command.SpaceId);

                await _notificationService.SendAsync(
                    user.Email,
                    "Reservation Created",
                    $"Your reservation for {space?.Name ?? "the space"} from {command.StartDate:yyyy-MM-dd} to {command.EndDate:yyyy-MM-dd} has been successfully created."
                );
            }

            return reservation.Id;
        }
    }
}
