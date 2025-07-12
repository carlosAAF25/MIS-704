using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Spaces.GetSpaces;

namespace Reservas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpacesController : ControllerBase
    {
        private readonly GetSpacesHandler _getSpacesHandler;

        public SpacesController(GetSpacesHandler getSpacesHandler)
        {
            _getSpacesHandler = getSpacesHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getSpacesHandler.HandleAsync(new GetSpacesQuery());
            return Ok(result);
        }
    }
}
