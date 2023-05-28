using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BallBuddies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
        {
            var result = await _unitOfWork.UserAuthentication.RegisterUser(userRegistrationDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }


            return StatusCode(201);

        }
    }
}
