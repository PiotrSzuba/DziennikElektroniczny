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
    public class DefaultGrades
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Grade.Any())
                {
                    return;
                }
                context.Grade.AddRange(
                    new Grade
                    {
                        StudentPersonId = 2,
                        TeacherPersonId = 1,
                        SubjectId = 3,
                        Value = "5+",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 2,
                        TeacherPersonId = 1,
                        SubjectId = 4,
                        Value = "4-",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 2,
                        TeacherPersonId = 1,
                        SubjectId = 5,
                        Value = "3",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 2,
                        TeacherPersonId = 1,
                        SubjectId = 6,
                        Value = "2",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 3,
                        TeacherPersonId = 1,
                        SubjectId = 3,
                        Value = "3-",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 3,
                        TeacherPersonId = 1,
                        SubjectId = 4,
                        Value = "5+",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 3,
                        TeacherPersonId = 1,
                        SubjectId = 5,
                        Value = "5--",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 3,
                        TeacherPersonId = 1,
                        SubjectId = 6,
                        Value = "5+",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 4,
                        TeacherPersonId = 1,
                        SubjectId = 3,
                        Value = "6-",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 4,
                        TeacherPersonId = 1,
                        SubjectId = 4,
                        Value = "1",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 4,
                        TeacherPersonId = 1,
                        SubjectId = 5,
                        Value = "5+",
                        Date = DateTime.Now
                    },
                    new Grade
                    {
                        StudentPersonId = 4,
                        TeacherPersonId = 1,
                        SubjectId = 6,
                        Value = "4-",
                        Date = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
