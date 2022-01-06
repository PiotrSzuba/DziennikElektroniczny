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
        static Person p1 = new Person
        {
            PersonalInfoId = 2,
            Role = 1,
            Login = "Login2",
            HashedPassword = "1234"
        };
        static Person p2 = new Person
        {
            PersonalInfoId = 3,
            Role = 1,
            Login = "Login3",
            HashedPassword = "1234"
        };
        static Person p3 = new Person
        {
            PersonalInfoId = 4,
            Role = 1,
            Login = "Login4",
            HashedPassword = "1234"
        };
        static Person p4 = new Person
        {
            PersonalInfoId = 5,
            Role = 1,
            Login = "Login5",
            HashedPassword = "1234"
        };
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
                        YearOfStudy = 2020,
                        Students = new List<Person> { p1,p2,p3,p4 }
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
