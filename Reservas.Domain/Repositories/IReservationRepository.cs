using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservas.Domain.Entities;

namespace Reservas.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task AddAsync(Reservation reservation);
        Task<bool> IsSpaceAvailable(Guid spaceId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Reservation>> GetByUserIdAsync(Guid userId);
        Task<Reservation> GetByIdAsync(Guid reservationId);
        Task UpdateAsync(Reservation reservation);
    }
}
