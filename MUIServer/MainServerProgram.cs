using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MUIServer.Controllers;
using MUIServer.Entities;
using MUIServer.Functionalities;
using MUIServer.Models;
using MUIServer.Models.Validators;
using MUIServer.Seeders;
using MUIServer.Services;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace MUIServer
{
    public class MainServerProgram
    {
        public static string serverName { get; set; }
        public static DateTime startTime { get; set; }
        public static string startTimeString { get; set; }
        public static DateTime endTime { get; set; }
        public static string endTimeString { get; set; }

        public static void Main()
        { 
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            
            builder.Services.AddDbContext<MainServerDbContext>();
            builder.Services.AddControllers().AddFluentValidation();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IPasswordHasher<ServerUser>, PasswordHasher<ServerUser>>();
            builder.Services.AddScoped<IValidator<RegisterUserDTO>, RegisterUserDTOValidator>();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var authenticationSettings = new AuthenticationSettings();
            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

            builder.Services.AddSingleton(authenticationSettings);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtIssuer))
                };
            });

            var app = builder.Build();
            
            ServerServices.AboutAuthor();
            ServerServices.ServerVersion();

            ServerServices.ServerName("test");

            var serverStartTime = DateTime.Now;
            startTime = serverStartTime;
            ServerServices.ServerStartTime(serverStartTime);
            startTimeString = serverStartTime.ToString("G", CultureInfo.CreateSpecificCulture("pl-Pl"));

            ServerServices.ServerIp();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Seed();

            app.Run();
        }
    }
}