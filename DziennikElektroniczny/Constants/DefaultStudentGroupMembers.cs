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
    public class DefaultStudentGroupMembers
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.StudentsGroupMember.Any())
                {
                    return;
                }
                context.StudentsGroupMember.AddRange(
                    new StudentsGroupMember
                    {
                        StudentsGroupId = 25,
                        StudentPersonId = 2,
                    },
                    new StudentsGroupMember
                    {
                        StudentsGroupId = 25,
                        StudentPersonId = 3,
                    },
                    new StudentsGroupMember
                    {
                        StudentsGroupId = 25,
                        StudentPersonId = 4,
                    },
                    new StudentsGroupMember
                    {
                        StudentsGroupId = 25,
                        StudentPersonId = 5,
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
