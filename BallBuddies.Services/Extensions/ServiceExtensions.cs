using BallBuddies.Data.Implementation;
using BallBuddies.Data.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BallBuddies.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
