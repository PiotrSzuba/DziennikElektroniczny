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
    public class DefaultParents
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Parent.Any())
                {
                    return;
                }
                context.Parent.AddRange(
                    new Parent
                    {
                        ParentPersonId = 6,
                        StudentPersonId = 2
                    },
                    new Parent
                    {
                        ParentPersonId = 7,
                        StudentPersonId = 2
                    },
                    new Parent
                    {
                        ParentPersonId = 6,
                        StudentPersonId = 3
                    },
                    new Parent
                    {
                        ParentPersonId = 7,
                        StudentPersonId = 3
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
