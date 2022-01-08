using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DziennikElektroniczny.Data;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.ViewModels;
namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsPageController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public EventsPageController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        private async Task<EventsPageView> CreateEventsPageView(Event @event)
        {
            var participants = await _context.EventParticipator.Where(x => x.EventId == @event.EventId).Select(x => x.PersonId).ToListAsync();
            List<string> fullNames = new();
            foreach (var participant in participants)
            {
                var person = await _context.Person.FindAsync(participant);
                var personInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
                fullNames.Add(personInfo.Name + personInfo.Surname);
            }
            if (@event == null)
            {
                return null;
            }

            return new EventsPageView
            {
                Title = @event.Title,
                Description = @event.Description,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                Participators = fullNames
            };
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventsPageView>>> GetEvent()
        {
            var events = await _context.Event.ToListAsync();
            List<EventsPageView> EventsViews = new();
            foreach (var @event in events)
            {
                EventsViews.Add(await CreateEventsPageView(@event));
            }
            return EventsViews;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventsPageView>> GetEvent(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            return await CreateEventsPageView(@event);
        }
    }
}
