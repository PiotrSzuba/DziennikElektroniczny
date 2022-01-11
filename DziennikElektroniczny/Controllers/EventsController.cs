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
        public async Task<EventView> CreateView(Event @event)
        {
            var participators = await _context.EventParticipator.Where(x => x.EventId == @event.EventId).ToListAsync();
            List<PersonalInfo> personalInfos = new();
            foreach(var participator in participators)
            {
                var person = await _context.Person.FindAsync(participator.PersonId);
                var personalInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
                personalInfos.Add(personalInfo);
            }
            return new EventView(@event,personalInfos);
        }

        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<EventView>>> GetEvent(
            int? id,int? eventId, string title, string description)
        {
            List<EventView> eventViews = new();
            List<Event> eventsList = new();
            if(id != null)
            {
                var @event = await _context.Event.FindAsync(id);
                if (@event == null)
                {
                    return NotFound();
                }
                eventViews.Add(await CreateView(@event));

                return eventViews;
            }
            if(eventId != null)
            {
                if(eventsList.Count == 0)
                {
                    eventsList = await _context.Event
                        .Where(x => x.EventId == eventId)
                        .ToListAsync();
                }
                else
                {
                    eventsList = await Task.FromResult(eventsList
                        .Where(x => x.EventId == eventId)
                        .ToList());
                }
            }
            if (title != null)
            {
                if(eventsList.Count == 0)
                {
                    eventsList = await _context.Event
                        .Where(x => x.Title.ToLower().Contains(title.ToLower()))
                        .ToListAsync();
                }
                else
                {
                    eventsList = await Task.FromResult(eventsList
                        .Where(x => x.Title.ToLower().Contains(title.ToLower()))
                        .ToList());
                }
            }
            if (description != null)
            {
                if (eventsList.Count == 0)
                {
                    eventsList = await _context.Event
                        .Where(x => x.Description.ToLower().Contains(description.ToLower()))
                        .ToListAsync();
                }
                else
                {
                    eventsList = await Task.FromResult(eventsList
                        .Where(x => x.Description.ToLower().Contains(description.ToLower()))
                        .ToList());
                }
            }
            if(id == null && eventId == null && title == null && description == null)
            {
                eventsList = await _context.Event.ToListAsync();
            }
            if(eventsList.Count == 0)
            {
                return NotFound();
            }

            foreach (var @event in eventsList)
            {
                eventViews.Add(await CreateView(@event));
            }

            return eventViews;

        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
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
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, await CreateView(@event));
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
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
