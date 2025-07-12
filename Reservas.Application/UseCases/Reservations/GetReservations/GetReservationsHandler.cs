using System.Collections.Generic;
using System.Threading.Tasks;
using Reservas.Domain.Entities;
using Reservas.Domain.Repositories;

namespace Reservas.Application.UseCases.Reservations.GetReservations
{
    public class GetReservationsHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> HandleAsync(GetReservationsQuery query)
        {
            if (query.UserId.HasValue)
                return await _reservationRepository.GetByUserIdAsync(query.UserId.Value);

            return await _reservationRepository.GetAllAsync();
        }
    }
}
