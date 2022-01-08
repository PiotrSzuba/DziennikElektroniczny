using System;
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
        public EventView(Event @event)
        {
            Id = @event.EventId;
            Title = @event.Title;
            Description = @event.Description;
            EndDate = @event.EndDate;
            StartDate = @event.StartDate;
        }
    }
}
