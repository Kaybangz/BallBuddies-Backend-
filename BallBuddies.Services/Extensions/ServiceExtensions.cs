
using BallBuddies.Models.Entities;
using BallBuddies.Services.Implementation;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BallBuddies.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services) => services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureUserAuth(this IServiceCollection services) => services.AddScoped<IUserAuthentication, UserAuthentication>();

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureUserManager(this IServiceCollection services) => services.AddScoped<UserManager<User>>();

    }
}
