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
                        EventId = 6,
                        PersonId = 1
                    },
                    new EventParticipator
                    {
                        EventId = 6,
                        PersonId = 2
                    },
                    new EventParticipator
                    {
                        EventId = 6,
                        PersonId = 3
                    },
                    new EventParticipator
                    {
                        EventId = 6,
                        PersonId = 4
                    },
                    new EventParticipator
                    {
                        EventId = 6,
                        PersonId = 5
                    },
                    new EventParticipator
                    {
                        EventId = 7,
                        PersonId = 1
                    },
                    new EventParticipator
                    {
                        EventId = 7,
                        PersonId = 2
                    },
                    new EventParticipator
                    {
                        EventId = 7,
                        PersonId = 3
                    },
                    new EventParticipator
                    {
                        EventId = 7,
                        PersonId = 4
                    },
                    new EventParticipator
                    {
                        EventId = 7,
                        PersonId = 5
                    },
                    new EventParticipator
                    {
                        EventId = 8,
                        PersonId = 1
                    },
                    new EventParticipator
                    {
                        EventId = 8,
                        PersonId = 2
                    },
                    new EventParticipator
                    {
                        EventId = 8,
                        PersonId = 3
                    },
                    new EventParticipator
                    {
                        EventId = 8,
                        PersonId = 4
                    },
                    new EventParticipator
                    {
                        EventId = 8,
                        PersonId = 5
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
