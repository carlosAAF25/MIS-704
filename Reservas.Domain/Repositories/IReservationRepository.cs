using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservas.Domain.Entities;

namespace Reservas.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetByIdAsync(Guid id);
        Task<IEnumerable<Reservation>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Reservation reservation);
        Task UpdateAsync(Reservation reservation);
        Task<bool> IsSpaceAvailable(Guid spaceId, DateTime start, DateTime end);
    }
}
