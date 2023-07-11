using BallBuddies.Models.Dtos.Response;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{
    [ApiController]
    [Route("api/token")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TokenController: ControllerBase
    {
        private readonly IServiceManager _service;

        public TokenController(IServiceManager service) => _service = service;


        /// <summary>
        /// Validates access token and refresh token
        /// </summary>
        /// <returns>The access token and refresh token</returns>
        /// <response code="200">Returns the access token and refresh token</response>
        /// <response code="500">Returns invalid client request</response>
        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }
        
    }
}
