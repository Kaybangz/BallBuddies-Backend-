using AutoMapper;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Entities;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace BallBuddies.Services.Implementation
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            var user = _mapper.Map<User>(userRegistrationDto);

            var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userRegistrationDto.Roles);
            }

            return result;

        }
    }
}
