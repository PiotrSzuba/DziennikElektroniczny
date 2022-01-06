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
    public class DefaultNotes
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Note.Any())
                {
                    return;
                }
                context.Note.AddRange(
                    new Note
                    {
                        StudentPersonId = 2,
                        TeacherPersonId = 1,
                        Description = "Using phone",
                        Date = DateTime.Now
                    },
                    new Note
                    {
                        StudentPersonId = 3,
                        TeacherPersonId = 1,
                        Description = "Chewing gum",
                        Date = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
