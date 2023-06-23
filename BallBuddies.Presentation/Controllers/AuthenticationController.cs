using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController: ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service) => _service = service;

        [HttpPost]
        /*[ServiceFilter(typeof(ValidationFilterAttribute))]*/
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
    }
}
