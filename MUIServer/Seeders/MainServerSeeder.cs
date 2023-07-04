using Cairo;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MUIServer.Entities;
using MUIServer.Functionalities;
using System.Globalization;

namespace MUIServer.Seeders
{
    public static class MainServerSeeder
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<MainServerDbContext>();
                try
                {
                    context.Database.EnsureCreated();

                    var mainServer = context.MainServer.FirstOrDefault();

                    if (mainServer == null)
                    {
                        context.MainServer.AddRange(

                            new MainServer
                            {
                                MainServerID = 0,
                                MainServerName = "DeveloperTest_Alpha",
                                MainServerVersion = "MUIServer v1.0.0 " + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day,
                                MainServerIP = "127.0.0.1",
                                MainServerPort = 8080,
                                MainServerURL = "https://localhost:7090/swagger",
                                MainServerTimeStart = MainServerProgram.startTimeString,
                                MainServerLivetime = MainServerProgram.startTimeString,
                                MainServerTimeEnd = MainServerProgram.startTimeString
                            });

                        context.SaveChanges();
                    }

                    var userRole = context.UserRoles.FirstOrDefault();

                    if (userRole == null)
                    {
                        context.UserRoles.AddRange(

                             new ServerUserRole
                             {
                                 Name = "Player"
                             });


                        context.UserRoles.AddRange(

                            new ServerUserRole()
                            {
                                Name = "Boot"
                            });

                        context.UserRoles.AddRange(

                            new ServerUserRole()
                            {
                                Name = "Administrator"
                            });


                        context.UserRoles.AddRange(

                            new ServerUserRole()
                            {
                                Name = "Developer"
                            });

                        context.SaveChanges();

                    }
                }



                catch (Exception)
                {
                    throw;
                }

                return app;

            }

        }

        /*private IEnumerable<UserRole> GetUserRole()
        {
            var roles = new List<UserRole>()
            {
                new UserRole()
                {
                    Name = "Player"
                },

                new UserRole()
                {
                    Name = "Boot"
                },

                new UserRole()
                {
                    Name = "Administrator"
                },

                new UserRole()
                {
                    Name = "Developer"
                }

            };

            return roles;

        }*/
      
    }
}
