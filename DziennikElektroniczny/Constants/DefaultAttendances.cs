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
    public class DefaultAttendances
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Attendance.Any())
                {
                    return;
                }
                context.Attendance.AddRange(
                    new Attendance
                    {
                        StudentPersonId = 2,
                        LessonId = 2,
                        WasPresent = 1,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 2,
                        LessonId = 3,
                        WasPresent = 1,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 2,
                        LessonId = 4,
                        WasPresent = 0,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 2,
                        LessonId = 5,
                        WasPresent = 0,
                        AbsenceNote = "Bolał go brzuch."
                    },
                    new Attendance
                    {
                        StudentPersonId = 3,
                        LessonId = 2,
                        WasPresent = 1,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 3,
                        LessonId = 3,
                        WasPresent = 0,
                        AbsenceNote = "Problemy zdrowotne"
                    },
                    new Attendance
                    {
                        StudentPersonId = 3,
                        LessonId = 4,
                        WasPresent = 1,
                        AbsenceNote = "Ciekawe czy sie zbuguje bo WasPresent = 1 "
                    },
                    new Attendance
                    {
                        StudentPersonId = 3,
                        LessonId = 5,
                        WasPresent = 0,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 4,
                        LessonId = 6,
                        WasPresent = 1,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 4,
                        LessonId = 2,
                        WasPresent = 0,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 4,
                        LessonId = 3,
                        WasPresent = 1,
                        AbsenceNote = null
                    },
                    new Attendance
                    {
                        StudentPersonId = 4,
                        LessonId = 4,
                        WasPresent = 0,
                        AbsenceNote = "Uspriewiedliwienie"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
