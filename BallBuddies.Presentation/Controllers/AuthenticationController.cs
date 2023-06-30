using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController: ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service) => _service = service;

        [HttpPost("register", Name = "Register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(userRegistrationDto);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }


        [HttpPost("login", Name = "Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }
    }
}
