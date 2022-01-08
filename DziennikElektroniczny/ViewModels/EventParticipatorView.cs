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
        public int? PersonId { get; set; }
        public EventParticipatorView(EventParticipator eventParticipator)
        {
            Id = eventParticipator.EventParticipatorId;
            EventId = eventParticipator.EventId;
            PersonId = eventParticipator.PersonId;
        }
    }
}
