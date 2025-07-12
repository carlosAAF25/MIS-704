using System;
using System.Threading.Tasks;
using Reservas.Domain.Entities;

namespace Reservas.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
