using DziennikElektroniczny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.ViewModels
{
    public class EventParticipatorView
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public string EventName { get; set; }
        public int? PersonId { get; set; }
        public string PersonName { get; set; }
        public EventParticipatorView(EventParticipator eventParticipator,Event @event, PersonalInfo personalInfo)
        {
            Id = eventParticipator.EventParticipatorId;
            EventId = eventParticipator.EventId;
            EventName = @event.Title;
            PersonId = eventParticipator.PersonId;
            PersonName = personalInfo.Name + " " + personalInfo.Surname;
        }
    }
}
