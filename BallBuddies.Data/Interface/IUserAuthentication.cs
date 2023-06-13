using BallBuddies.Models.Dtos.Request;
using Microsoft.AspNetCore.Identity;

namespace BallBuddies.Data.Interface
{
    public interface IUserAuthentication
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto user);
    }
}
