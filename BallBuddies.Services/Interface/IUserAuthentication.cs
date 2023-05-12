using BallBuddies.Models.Dtos;
using Microsoft.AspNetCore.Identity;

namespace BallBuddies.Services.Interface
{
    public interface IUserAuthentication
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto user);
    }
}
