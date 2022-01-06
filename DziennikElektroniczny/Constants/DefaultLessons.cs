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
    public class DefaultLessons
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Lesson.Any())
                {
                    return;
                }
                context.Lesson.AddRange(
                    new Lesson
                    {
                        TeacherPersonId = 1,
                        SubjectId = 3,
                        Topic = "Dodawanie",
                        Date = DateTime.Now
                    },
                    new Lesson
                    {
                        TeacherPersonId = 1,
                        SubjectId = 4,
                        Topic = "Całki",
                        Date = DateTime.Now
                    },
                    new Lesson
                    {
                        TeacherPersonId = 1,
                        SubjectId = 5,
                        Topic = "Podwójne całki",
                        Date = DateTime.Now
                    },
                    new Lesson
                    {
                        TeacherPersonId = 1,
                        SubjectId = 6,
                        Topic = "Wektory",
                        Date = DateTime.Now
                    },
                    new Lesson
                    {
                        TeacherPersonId = 1,
                        SubjectId = 4,
                        Topic = "Odejmowanie",
                        Date = DateTime.Now
                    },
                    new Lesson
                    {
                        TeacherPersonId = 1,
                        SubjectId = 5,
                        Topic = "Całki część dalsza",
                        Date = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
