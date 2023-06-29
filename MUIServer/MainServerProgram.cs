using MUIServer.Entities;
using MUIServer.Functionalities;
using MUIServer.Seeders;
using System.Globalization;

namespace MUIServer
{
    public class MainServerProgram
    {
        public static DateTime startTime { get; set; }
        public static string startTimeString { get; set; }
        public static DateTime endTime { get; set; }
        public static string endTimeString { get; set; }

        public static void Main()
        { 
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddDbContext<MainServerDbContext>();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            ServerServices.AboutAuthor();
            ServerServices.ServerVersion();
            
            var serverName = "Test Server 00";
            ServerServices.ServerName(serverName);

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Seed();

            app.Run();
        }
    }
}