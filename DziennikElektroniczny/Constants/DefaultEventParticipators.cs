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
    public class DefaultEventParticipators
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.EventParticipator.Any())
                {
                    return;
                }
                context.EventParticipator.AddRange(
                    new EventParticipator
                    {

                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
