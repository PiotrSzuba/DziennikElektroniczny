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
    public class DefaultPersons
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Person.Any())
                {
                    return;
                }
                context.Person.AddRange
                (
                    //be advised of changing this data
                    //the same values are needed in events and student groups !!!!!
                    new Person
                    {
                        PersonalInfoId = 1,
                        Role = 0,
                        Login = "Login1",
                        HashedPassword = "1234"
                    },
                    new Person
                    {
                        PersonalInfoId = 2,
                        Role = 1,
                        Login = "Login2",
                        HashedPassword = "1234"
                    },
                    new Person
                    {
                        PersonalInfoId = 3,
                        Role = 1,
                        Login = "Login3",
                        HashedPassword = "1234"
                    },
                    new Person
                    {
                        PersonalInfoId = 4,
                        Role = 1,
                        Login = "Login4",
                        HashedPassword = "1234"
                    },
                    new Person
                    {
                        PersonalInfoId = 5,
                        Role = 1,
                        Login = "Login5",
                        HashedPassword = "1234"
                    },
                    new Person
                    {
                        PersonalInfoId = 6,
                        Role = 2,
                        Login = "Login6",
                        HashedPassword = "1234"
                    },
                    new Person
                    {
                        PersonalInfoId = 7,
                        Role = 2,
                        Login = "Login7",
                        HashedPassword = "1234"
                    }, new Person
                    {
                        PersonalInfoId = 8,
                        Role = 0,
                        Login = "Login9",
                        HashedPassword = "1234"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
