
using BallBuddies.Data.Interface;
using BallBuddies.Data.Implementation;
using BallBuddies.Models.Entities;
using BallBuddies.Services.Implementation;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BallBuddies.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Services.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureUserManager(this IServiceCollection services) =>
            services.AddScoped<UserManager<User>>();

        public static void ConfigureUnitOfWork(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureServiceManager(this IServiceCollection services) => 
            services.AddScoped<IServiceManager, ServiceManager>();


        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<BallBuddiesDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });


        public static void ConfigureIdentity(this IServiceCollection services) =>
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequiredLength = 5;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<BallBuddiesDBContext>()
            .AddDefaultTokenProviders();


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
#pragma warning disable CS8604 // Possible null reference argument.
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
#pragma warning restore CS8604 // Possible null reference argument.
            });
        }


        public static void ConfigureLoggerMananger(this IServiceCollection services) => 
            services.AddSingleton<ILoggerManager, LoggerManager>();


    }
}
