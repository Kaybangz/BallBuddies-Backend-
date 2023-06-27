﻿using BallBuddies.Models.Dtos.Request;
using Microsoft.AspNetCore.Identity;

namespace BallBuddies.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto);
        Task<bool> ValidateUser(UserAuthenticationDto userAuth);
        Task<string> CreateToken();
    }
}
