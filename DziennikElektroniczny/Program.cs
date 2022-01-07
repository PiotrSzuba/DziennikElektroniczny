using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace DziennikElektroniczny
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    DefaultPersonalInfo.Initialize(services);
                    DefaultPersons.Initialize(services);
                    DefaultParents.Initialize(services);
                    DefaultNotes.Initialize(services);
                    DefaultMessageContents.Initialize(services);
                    DefaultMessages.Initialize(services);
                    DefaultClassrooms.Initialize(services);
                    DefaultSubjectInfos.Initialize(services);
                    DefaultStudentGroups.Initialize(services);
                    DefaultStudentGroupMembers.Initialize(services);
                    DefaultSubjects.Initialize(services);
                    DefaultGrades.Initialize(services);
                    DefaultLessons.Initialize(services);
                    DefaultAttendances.Initialize(services);
                    DefaultEvents.Initialize(services);
                    DefaultEventParticipators.Initialize(services);
                    logger.LogInformation("Finished Seeding Default Data");
                    logger.LogInformation("Application Starting");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
