using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DziennikElektroniczny.Data;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Constants
{
    public class DefaultEvents
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Event.Any())
                {
                    return;
                }
                context.Event.AddRange(
                    new Event
                    {
                        Title = "Zakończenie roku",
                        Description = "Rozdanie dyplomów",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now
                    },
                    new Event
                    {
                        Title = "Wycieczka",
                        Description = "Wycieczka do więzienia w sztumie",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now
                    },
                    new Event
                    {
                        Title = "Rozpoczęcie roku",
                        Description = "Przywitanie nowych uczniów",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
