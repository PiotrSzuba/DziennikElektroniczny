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
    public class DefaultMessages
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.Message.Any())
                {
                    return;
                }
                context.Message.AddRange(
                    new Message
                    {
                        MessageContentId = 1,
                        FromPersonId = 2,
                        ToPersonId = 1,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 2,
                        FromPersonId = 1,
                        ToPersonId = 2,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 3,
                        FromPersonId = 2,
                        ToPersonId = 1,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 4,
                        FromPersonId = 3,
                        ToPersonId = 1,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 5,
                        FromPersonId = 1,
                        ToPersonId = 3,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 6,
                        FromPersonId = 6,
                        ToPersonId = 7,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 7,
                        FromPersonId = 7,
                        ToPersonId = 6,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 8,
                        FromPersonId = 2,
                        ToPersonId = 1,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 9,
                        FromPersonId = 4,
                        ToPersonId = 5,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 10,
                        FromPersonId = 5,
                        ToPersonId = 4,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 11,
                        FromPersonId = 2,
                        ToPersonId = 1,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 12,
                        FromPersonId = 2,
                        ToPersonId = 3,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    },
                    new Message
                    {
                        MessageContentId = 13,
                        FromPersonId = 3,
                        ToPersonId = 4,
                        SendDate = DateTime.Now,
                        SeenDate = DateTime.Now
                    }
                    );
                context.SaveChanges();

            }
        }
    }
}
