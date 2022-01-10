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
    public class DefaultSubjects
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Subject.Any())
                {
                    return;
                }
                context.Subject.AddRange(
                    new Subject
                    {
                        SubjectInfoId = 1,
                        TeacherPersonId = 8,
                        StudentsGroupId = 1,
                        ClassRoomId = 1
                    },
                    new Subject
                    {
                        SubjectInfoId = 4,
                        TeacherPersonId = 1,
                        StudentsGroupId = 1,
                        ClassRoomId = 2
                    },
                    new Subject
                    {
                        SubjectInfoId = 7,
                        TeacherPersonId = 1,
                        StudentsGroupId = 1,
                        ClassRoomId = 1
                    },
                    new Subject
                    {
                        SubjectInfoId = 5,
                        TeacherPersonId = 8,
                        StudentsGroupId = 1,
                        ClassRoomId = 4
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
