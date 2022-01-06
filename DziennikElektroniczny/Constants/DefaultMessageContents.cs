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
    public class DefaultMessageContents
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DziennikElektronicznyContext(
                serviceProvider.GetRequiredService<
                 DbContextOptions<DziennikElektronicznyContext>>()))
            {
                if (context.MessageContent.Any())
                {
                    return;
                }
                context.MessageContent.AddRange(
                    new MessageContent
                    {
                        Title = "Pomoc",
                        Content = "Siema masz może gotowce na przyrke ?"
                    },
                    new MessageContent
                    {
                        Title = "Pomoc",
                        Content = "Tak mam dam ci za paczke czipsów"
                    },
                    new MessageContent
                    {
                        Title = "Pytanie o sprawdzian",
                        Content = "Dzień dobry chciałbym się zapytac z jakich tematów będzie sprawdzian"
                    },
                    new MessageContent
                    {
                        Title = "Pytanie o sprawdzian",
                        Content = "Dzień dobry, trzeba było słuchać na lekcji pozdrawiam."
                    },
                    new MessageContent
                    {
                        Title = "Pilna sprawa",
                        Content = "Dzień dobry chciałabym zgłosić że jestem notorycznie prześladowana przez ***."
                    },
                    new MessageContent
                    {
                        Title = "Pilna sprawa",
                        Content = "Dzień dobry z mojego doświadczenia wiem że zwykłe podanie sobie ręki zadziała mam wykształcenie w tej dziedzinie."
                    },
                    new MessageContent
                    {
                        Title = "TEST",
                        Content = "TEST MSG "
                    },
                    new MessageContent
                    {
                        Title = "TEST2",
                        Content = "TEST2 MSG2 "
                    },
                    new MessageContent
                    {
                        Title = "Przykład",
                        Content = "Czy ty masz rozum i godność człowieka ?"
                    },
                    new MessageContent
                    {
                        Title = "Skarga",
                        Content = "Chciałbym się poskarżyć na ***"
                    },
                    new MessageContent
                    {
                        Title = "Przypomnienie",
                        Content = "Chcicała bym przypomnieć że jutro jest praca do oddania"
                    },
                    new MessageContent
                    {
                        Title = "WF",
                        Content = "Czy moglibyśmy jutro zagrać w gałe na wf-ie ?"
                    },
                     new MessageContent
                    {
                        Title = "WF",
                        Content = "Jeszcze jak !"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
