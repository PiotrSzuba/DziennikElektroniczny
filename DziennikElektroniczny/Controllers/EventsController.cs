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
    public class EventsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public EventsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        private async Task<EventsView> CreateEventsView(Event @event)
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

            return new EventsView
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
        public async Task<ActionResult<IEnumerable<EventsView>>> GetEvent()
        {
            var events = await _context.Event.ToListAsync();
            List<EventsView> EventsViews = new();
            foreach (var @event in events)
            {
                EventsViews.Add(await CreateEventsView(@event));
            }
            return EventsViews;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventsView>> GetEvent(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            return await CreateEventsView(@event);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.EventId)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
