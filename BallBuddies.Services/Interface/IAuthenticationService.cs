using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using Microsoft.AspNetCore.Identity;

namespace BallBuddies.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto);
        Task<bool> ValidateUser(UserAuthenticationDto userAuth);
        Task LogOut();
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
