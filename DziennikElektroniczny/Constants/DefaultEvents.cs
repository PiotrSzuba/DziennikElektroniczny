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
    public class DefaultEvents
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
                if (context.Event.Any())
                {
                    return;
                }
                context.Event.AddRange(
                    new Event
                    {
                        Title = "Zakończenie roku",
                        Description = "Rozdanie dyplomów",
                        Persons = new List<Person> { p1, p2, p3, p4 },
                        StartDate = DateTime.Now,
                        DndDate = DateTime.Now
                    },
                    new Event
                    {
                        Title = "Wycieczka",
                        Description = "Wycieczka do więzienia w sztumie",
                        Persons = new List<Person> { p1, p2, p3, p4 },
                        StartDate = DateTime.Now,
                        DndDate = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
