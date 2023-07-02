using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BallBuddies.Presentation.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UsersController: ControllerBase
    {
        private readonly IServiceManager _service;
        public UsersController(IServiceManager service) => _service = service;


        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.UserService.GetAllUsersAsync(trackChanges: false);

            return Ok(users);
        }
    }
}
