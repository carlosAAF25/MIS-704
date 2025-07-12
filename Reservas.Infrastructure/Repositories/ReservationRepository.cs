using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Entities;
using Reservas.Domain.Repositories;
using Reservas.Infrastructure.Data;

namespace Reservas.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationsDbContext _context;

        public ReservationRepository(ReservationsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsSpaceAvailable(Guid spaceId, DateTime startDate, DateTime endDate)
        {
            return !await _context.Reservations.AnyAsync(
                r =>
                    r.SpaceId == spaceId
                    && (
                        (startDate >= r.StartDate && startDate < r.EndDate)
                        || (endDate > r.StartDate && endDate <= r.EndDate)
                        || (startDate <= r.StartDate && endDate >= r.EndDate)
                    )
            );
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Reservations.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(Guid reservationId)
        {
            return await _context.Reservations.FindAsync(reservationId);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
