using BallBuddies.Services.Extensions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Diagnostics;
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
			builder.Services.ConfigureSqlContext(builder.Configuration);

			builder.Services.ConfigureUserManager();
			builder.Services.ConfigureUnitOfWork();
			builder.Services.ConfigureServiceManager();
			builder.Services.ConfigureLoggerMananger();
			builder.Services.ConfigureIdentity();
			builder.Services.ConfigureCors();
			builder.Services.ConfigureIISIntegration();


			builder.Services.AddControllers()
				.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAuthentication();

			


			builder.Services.ConfigureJWT(builder.Configuration);


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			var logger = app.Services.GetRequiredService<ILoggerManager>();
			app.ConfigureExceptionHandler(logger);

			/*if (app.Environment.IsProduction())
				app.UseHsts();*/

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseDeveloperExceptionPage();
			}
			else
				app.UseHsts();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.All
			});

			app.UseCors("CorsPolicy");

			app.UseAuthentication();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}