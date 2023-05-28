using BallBuddies.Models.Dtos.Request;
using Microsoft.AspNetCore.Identity;

namespace BallBuddies.Services.Interface
{
    public interface IUserAuthentication
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto user);
    }
}
