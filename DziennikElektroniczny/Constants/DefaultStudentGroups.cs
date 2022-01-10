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
    public class DefaultStudentGroups
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.StudentsGroup.Any())
                {
                    return;
                }
                context.StudentsGroup.AddRange(
                    new StudentsGroup
                    {
                        TeacherPersonId = 1,
                        Title = "1A",
                        Description = "Fresh meat",
                        YearOfStudy = 2020
                    },
                    new StudentsGroup
                    {
                        TeacherPersonId = 8,
                        Title = "1B",
                        Description = "Fresh meat",
                        YearOfStudy = 2020
                    },
                    new StudentsGroup
                    {
                        TeacherPersonId = 1,
                        Title = "2A",
                        Description = "Expirienced meat",
                        YearOfStudy = 2019
                    },
                    new StudentsGroup
                    {
                        TeacherPersonId = 8,
                        Title = "2B",
                        Description = "Experienced meat",
                        YearOfStudy = 2019
                    },
                    new StudentsGroup
                    {
                        TeacherPersonId = 1,
                        Title = "3A",
                        Description = "Old meat",
                        YearOfStudy = 2018
                    },
                    new StudentsGroup
                    {
                        TeacherPersonId = 8,
                        Title = "3A",
                        Description = "Old meat",
                        YearOfStudy = 2018
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
