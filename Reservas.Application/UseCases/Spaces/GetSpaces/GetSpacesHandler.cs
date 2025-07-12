using System.Collections.Generic;
using System.Threading.Tasks;
using Reservas.Domain.Entities;
using Reservas.Domain.Repositories;

namespace Reservas.Application.UseCases.Spaces.GetSpaces
{
    public class GetSpacesHandler
    {
        private readonly ISpaceRepository _spaceRepository;

        public GetSpacesHandler(ISpaceRepository spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        public async Task<IEnumerable<Space>> HandleAsync(GetSpacesQuery query)
        {
            return await _spaceRepository.GetAllAsync();
        }
    }
}
