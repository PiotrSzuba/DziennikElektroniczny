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
    public class DefaultSubjectInfos
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.SubjectInfo.Any())
                {
                    return;
                }
                context.SubjectInfo.AddRange(
                    new SubjectInfo
                    {
                        Title = "Math",
                        Description = "Basic math"
                    },
                    new SubjectInfo
                    {
                        Title = "Chemistry",
                        Description = "Basic chemistry"
                    },
                    new SubjectInfo
                    {
                        Title = "Science",
                        Description = "Basic science"
                    },
                    new SubjectInfo
                    {
                        Title = "PE",
                        Description = "Basic pe"
                    },
                    new SubjectInfo
                    {
                        Title = "Advanced Math 1",
                        Description = "Lineal algebra"
                    },
                    new SubjectInfo
                    {
                        Title = "Advanced Math 2",
                        Description = "Basic Calculus "
                    },
                    new SubjectInfo
                    {
                        Title = "Advanced Math 3",
                        Description = "Advanced Calculus "
                    },
                    new SubjectInfo
                    {
                        Title = "Biology",
                        Description = "Basic biology"
                    },
                    new SubjectInfo
                    {
                        Title = "English",
                        Description = "Basic English"
                    },
                    new SubjectInfo
                    {
                        Title = "Philosophy",
                        Description = "Basic philosophy"
                    },
                    new SubjectInfo
                    {
                        Title = "Classical literature",
                        Description = "Basic classical literature"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
