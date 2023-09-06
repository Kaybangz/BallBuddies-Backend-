using AspNetCoreRateLimit;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Extensions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
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
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.AddJwtConfiguration(builder.Configuration);
            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddMemoryCache();
            builder.Services.ConfigureRateLimitingOptions();
            builder.Services.AddHttpContextAccessor();


            NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
                new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services
                .BuildServiceProvider()
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();


            builder.Services.Configure<ApiBehaviorOptions>(options => 
            options.SuppressModelStateInvalidFilter = true
            ) ;
            builder.Services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            }).AddXmlDataContractSerializerFormatters()
            .AddCustomCSVFormatter()
            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            builder.Services.AddScoped<ValidationFilterAttribute>();

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BallBuddies_Api",
                    Version = "v1",
                    Description = "BallBuddies API by Caleb Okechukwu",
                    Contact = new OpenApiContact
                    {
                        Name = "Caleb Okechukwu",
                        Email = "devcaleb96@gmail.com",
                        Url = new Uri("https://www.linkedIn.com/in/igcaleb"),
                    }
                });

                var xmlFile = $"{typeof(Presentation.AssemblyReference).Assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);


                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
                    "Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },

                new string[] {}
                }
                 });
            });


            builder.Services.AddAuthentication();


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


            app.UseIpRateLimiting();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}