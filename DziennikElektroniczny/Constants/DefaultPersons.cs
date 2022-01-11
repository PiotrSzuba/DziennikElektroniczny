using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Utils;
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
                        Role = 1,
                        Login = "Login1",
                        HashedPassword = Hasher.hashEncoder("1234")
                    },
                    new Person
                    {
                        PersonalInfoId = 2,
                        Role = 2,
                        Login = "Login2",
                        HashedPassword = Hasher.hashEncoder("1234")
                    },
                    new Person
                    {
                        PersonalInfoId = 3,
                        Role = 2,
                        Login = "Login3",
                        HashedPassword = Hasher.hashEncoder("1234")
                    },
                    new Person
                    {
                        PersonalInfoId = 4,
                        Role = 2,
                        Login = "Login4",
                        HashedPassword = Hasher.hashEncoder("1234")
                    },
                    new Person
                    {
                        PersonalInfoId = 5,
                        Role = 2,
                        Login = "Login5",
                        HashedPassword = Hasher.hashEncoder("1234")
                    },
                    new Person
                    {
                        PersonalInfoId = 6,
                        Role = 3,
                        Login = "Login6",
                        HashedPassword = Hasher.hashEncoder("1234")
                    },
                    new Person
                    {
                        PersonalInfoId = 7,
                        Role = 3,
                        Login = "Login7",
                        HashedPassword = Hasher.hashEncoder("1234")
                    }, new Person
                    {
                        PersonalInfoId = 8,
                        Role = 1,
                        Login = "Login9",
                        HashedPassword = Hasher.hashEncoder("1234")
                    }, 
                    new Person
                    {
                        PersonalInfoId = 1,
                        Role = 4,
                        Login = "Admin",
                        HashedPassword = Hasher.hashEncoder("1234")
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
