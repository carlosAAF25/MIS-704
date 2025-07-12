using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservas.Domain.Entities;

namespace Reservas.Domain.Repositories
{
    public interface ISpaceRepository
    {
        Task<Space> GetByIdAsync(Guid id);
        Task<IEnumerable<Space>> GetAllAsync();
        Task AddAsync(Space space);
    }
}
