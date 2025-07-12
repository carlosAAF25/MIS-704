using Reservas.Domain.Entities;
using Reservas.Domain.Repositories;

namespace Reservas.Application.UseCases.Users.GetUsers
{
    public class GetUsersHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> HandleAsync(GetUsersQuery query)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
