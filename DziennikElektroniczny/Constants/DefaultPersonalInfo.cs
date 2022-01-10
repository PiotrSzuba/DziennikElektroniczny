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
    public class DefaultPersonalInfo
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.PersonalInfo.Any())
                {
                    return;
                }
                context.PersonalInfo.AddRange(
                    new PersonalInfo
                    {
                        Name = "Name1",
                        SecondName = "SecName1",
                        Surname = "SurName1",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel1",
                        Address = "Address 1",
                        Pesel = "Pesel1"
                    },
                    new PersonalInfo
                    {
                        Name = "Name2",
                        SecondName = "SecName2",
                        Surname = "SurName2",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel2",
                        Address = "Address 2",
                        Pesel = "Pesel2"
                    },
                    new PersonalInfo
                    {
                        Name = "Name3",
                        SecondName = "SecName3",
                        Surname = "SurName3",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel3",
                        Address = "Address 3",
                        Pesel = "Pesel3"
                    }, new PersonalInfo
                    {
                        Name = "Name4",
                        SecondName = "SecName4",
                        Surname = "SurName4",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel4",
                        Address = "Address 4",
                        Pesel = "Pesel4"
                    }, new PersonalInfo
                    {
                        Name = "Name5",
                        SecondName = "SecName5",
                        Surname = "SurName5",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel6",
                        Address = "Address 6",
                        Pesel = "Pesel6"
                    }, new PersonalInfo
                    {
                        Name = "Name6",
                        SecondName = "SecName6",
                        Surname = "SurName6",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel6",
                        Address = "Address 6",
                        Pesel = "Pesel6"
                    }, new PersonalInfo
                    {
                        Name = "Name7",
                        SecondName = "SecName7",
                        Surname = "SurName7",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel7",
                        Address = "Address 7",
                        Pesel = "Pesel7"
                    },new PersonalInfo
                    {
                        Name = "Zemsta",
                        SecondName = "",
                        Surname = "Salhazara",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "tel8",
                        Address = "Address 8",
                        Pesel = "Pesel8"
                    }
                    ) ;
                context.SaveChanges();
            }
        }
    }
}
