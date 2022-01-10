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
                        EventId = 1,
                        PersonId = 1
                    },
                    new EventParticipator
                    {
                        EventId = 1,
                        PersonId = 2
                    },
                    new EventParticipator
                    {
                        EventId = 1,
                        PersonId = 3
                    },
                    new EventParticipator
                    {
                        EventId = 1,
                        PersonId = 4
                    },
                    new EventParticipator
                    {
                        EventId = 1,
                        PersonId = 5
                    },
                    new EventParticipator
                    {
                        EventId = 2,
                        PersonId = 1
                    },
                    new EventParticipator
                    {
                        EventId = 2,
                        PersonId = 2
                    },
                    new EventParticipator
                    {
                        EventId = 2,
                        PersonId = 3
                    },
                    new EventParticipator
                    {
                        EventId = 2,
                        PersonId = 4
                    },
                    new EventParticipator
                    {
                        EventId = 2,
                        PersonId = 5
                    },
                    new EventParticipator
                    {
                        EventId = 3,
                        PersonId = 1
                    },
                    new EventParticipator
                    {
                        EventId = 3,
                        PersonId = 2
                    },
                    new EventParticipator
                    {
                        EventId = 3,
                        PersonId = 3
                    },
                    new EventParticipator
                    {
                        EventId = 3,
                        PersonId = 4
                    },
                    new EventParticipator
                    {
                        EventId = 3,
                        PersonId = 5
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
