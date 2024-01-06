using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service) => _service = service;


        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="userRegistrationDto"></param>
        /// <returns>New user registered</returns>
        /// <response code="200">Returns access and refresh tokens</response>
        /// <response code="422">Returns password required</response>
        /// <response code="400">Returns duplicate username</response>
        [HttpPost("Register", Name = "Register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(422)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(userRegistrationDto);

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

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <param name="userAuthenticationDto"></param>
        /// <returns>A generated access token and refresh token</returns>
        /// <response code="200">Returns Login successful</response>
        /// <response code="401">Returns unauthorized access</response>
        [HttpPost("Login", Name = "Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserAuthenticationDto userAuthenticationDto)
        {
            if (!await _service.AuthenticationService.ValidateUser(userAuthenticationDto))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            return Ok(new
            {
                success = true,
                tokenDto
            });
        }

        //// <summary>
        /// Logs out a user
        /// </summary>
        /// <returns>A generated access token and refresh token</returns>
        /// <response code="200">Returns Logout successful</response>
        /// <response code="401">Returns unauthorized access</response>
        /*[HttpPost("Logout", Name = "Logout")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> LogOutUser()
        {

            await _service.AuthenticationService.LogOut();

            return Ok(new
            {
                Success = true,
                StatusCode = 200,
                Message = "You have been successfully logged out."
            });
        }*/
    }
}