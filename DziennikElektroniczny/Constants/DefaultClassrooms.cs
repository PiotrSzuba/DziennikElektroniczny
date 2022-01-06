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
    public class DefaultClassrooms
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.ClassRoom.Any())
                {
                    return;
                }
                context.ClassRoom.AddRange(
                    new ClassRoom
                    {
                        Building = "A1",
                        Floor = "0",
                        Destination = "1"
                    },
                    new ClassRoom
                    {
                        Building = "A1",
                        Floor = "0",
                        Destination = "2"
                    },
                    new ClassRoom
                    {
                        Building = "A1",
                        Floor = "0",
                        Destination = "3"
                    },
                    new ClassRoom
                    {
                        Building = "A1",
                        Floor = "1",
                        Destination = "1"
                    },
                    new ClassRoom
                    {
                        Building = "A1",
                        Floor = "0",
                        Destination = "2"
                    },
                    new ClassRoom
                    {
                        Building = "A1",
                        Floor = "1",
                        Destination = "3"
                    },
                    new ClassRoom
                    {
                        Building = "A2",
                        Floor = "0",
                        Destination = "1"
                    },
                    new ClassRoom
                    {
                        Building = "A2",
                        Floor = "0",
                        Destination = "2"
                    },
                    new ClassRoom
                    {
                        Building = "A2",
                        Floor = "0",
                        Destination = "3"
                    },
                    new ClassRoom
                    {
                        Building = "A2",
                        Floor = "1",
                        Destination = "1"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
