using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Users.GetUsers;

namespace Reservas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly GetUsersHandler _getUsersHandler;

        public UsersController(GetUsersHandler getUsersHandler)
        {
            _getUsersHandler = getUsersHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getUsersHandler.HandleAsync(new GetUsersQuery());
            return Ok(result);
        }
    }
}
