using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservas.Domain.Entities;

namespace Reservas.Domain.Repositories
{
    public interface ISpaceRepository
    {
        Task<IEnumerable<Space>> GetAllAsync();
        Task<Space?> GetByIdAsync(Guid id);
        Task AddAsync(Space space);
    }
}
