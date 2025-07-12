using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Entities;
using Reservas.Domain.Repositories;
using Reservas.Infrastructure.Data;

namespace Reservas.Infrastructure.Repositories
{
    public class SpaceRepository : ISpaceRepository
    {
        private readonly ReservationsDbContext _context;

        public SpaceRepository(ReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Space>> GetAllAsync()
        {
            return await _context.Spaces.Where(s => s.IsActive).ToListAsync();
        }

        public async Task<Space?> GetByIdAsync(Guid id)
        {
            return await _context.Spaces.FindAsync(id);
        }

        public async Task AddAsync(Space space)
        {
            await _context.Spaces.AddAsync(space);
            await _context.SaveChangesAsync();
        }
    }
}
