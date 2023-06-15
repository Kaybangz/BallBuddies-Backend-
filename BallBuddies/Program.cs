using BallBuddies.Data.Context;
using BallBuddies.Models.Entities;
using BallBuddies.Services.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace BallBuddies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            //Database connection string
            builder.Services.AddDbContext<BallBuddiesDBContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DbConnection");
                options.UseSqlServer(connectionString);
            });
            builder.Services.ConfigureUnitOfWork();
            builder.Services.ConfigureUserAuth();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureUserManager();




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAuthentication();
            builder.Services.AddIdentity<User, IdentityRole>(o =>
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

            builder.Services.ConfigureJWT(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}