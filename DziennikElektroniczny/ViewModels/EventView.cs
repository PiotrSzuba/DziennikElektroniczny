using System;
using System.Collections.Generic;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class EventView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public List<string> Participators { get; set; } = new List<string>();
        public EventView(Event @event,List<PersonalInfo> personalInfos)
        {
            Id = @event.EventId;
            Title = @event.Title;
            Description = @event.Description;
            EndDate = @event.EndDate;
            StartDate = @event.StartDate;
            foreach(var personalInfo in personalInfos)
            {
                Participators.Add(personalInfo.Name + " " + personalInfo.Surname);
            }
        }
    }
}
