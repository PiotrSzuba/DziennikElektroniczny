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
using DziennikElektroniczny.Utils;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventParticipatorsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public EventParticipatorsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        public async Task<EventParticipatorView> CreateView(EventParticipator eventParticipator)
        {
            var @event = await _context.Event.FindAsync(eventParticipator.EventId);

            var person = await _context.Person.FindAsync(eventParticipator.PersonId);
            var personalInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);

            return new EventParticipatorView(eventParticipator,@event, personalInfo);
        }

        // GET: api/EventParticipators
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<EventParticipatorView>>> GetEventParticipator(
            int? id,int? eventId,int? personId,string eventName,string personName)
        {
            List<EventParticipator> eventParticipatorsList = new();
            List<EventParticipatorView> eventParticipatorViews = new();
            if(id != null)
            {
                var eventParticipator = await _context.EventParticipator.FindAsync(id);

                if (eventParticipator == null)
                {
                    return NotFound();
                }

                eventParticipatorViews.Add(await CreateView(eventParticipator));

                return eventParticipatorViews;
            }
            if(eventId != null)
            {
                if(eventParticipatorsList.Count == 0)
                {
                    eventParticipatorsList = await _context.EventParticipator
                        .Where(x => x.EventId == eventId)
                        .ToListAsync();
                }
                else
                {
                    eventParticipatorsList = await Task.FromResult(eventParticipatorsList
                        .Where(x => x.EventId == eventId)
                        .ToList());
                }
            }
            if(personId != null)
            {
                if (eventParticipatorsList.Count == 0)
                {
                    eventParticipatorsList = await _context.EventParticipator
                        .Where(x => x.PersonId == personId)
                        .ToListAsync();
                }
                else
                {
                    eventParticipatorsList = await Task.FromResult(eventParticipatorsList
                        .Where(x => x.PersonId == personId)
                        .ToList());
                }
            }
            if(eventName != null)
            {
                List<EventParticipator> eventParticipators = new();
                if (eventParticipatorsList.Count == 0)
                {
                    eventParticipatorsList = await _context.EventParticipator.ToListAsync();
                }
                foreach(var eventParticipator in eventParticipatorsList)
                {
                    var @event = await _context.Event.FindAsync(eventParticipator.EventId);
                    if(@event.Title.ToLower().Contains(eventName.ToLower()))
                    {
                        eventParticipators.Add(eventParticipator);
                    }
                }
                eventParticipatorsList = eventParticipators;
            }
            if(personName != null)
            {
                List<EventParticipator> eventParticipators = new();
                if (eventParticipatorsList.Count == 0)
                {
                    eventParticipatorsList = await _context.EventParticipator.ToListAsync();
                }
                foreach (var eventParticipator in eventParticipatorsList)
                {
                    var person = await _context.Person.FindAsync(eventParticipator.PersonId);
                    var personalInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
                    var name = personalInfo.Name + " " + personalInfo.Surname;
                    if(name.ToLower().Contains(personName.ToLower()))
                    {
                        eventParticipators.Add(eventParticipator);
                    }
                }
                eventParticipatorsList = eventParticipators;
            }
            if(id == null && eventId == null && personId == null && eventName == null && personName == null)
            {
                eventParticipatorsList = await _context.EventParticipator.ToListAsync();
            }

            if(eventParticipatorsList.Count == 0)
            {
                return NotFound();
            }

            foreach(var eventParticipator in eventParticipatorsList)
            {
                eventParticipatorViews.Add(await CreateView(eventParticipator));
            }

            return eventParticipatorViews;
        }

        // PUT: api/EventParticipators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<IActionResult> PutEventParticipator(int id, EventParticipator eventParticipator)
        {
            if (id != eventParticipator.EventParticipatorId)
            {
                return BadRequest();
            }

            _context.Entry(eventParticipator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventParticipatorExists(id))
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

        // POST: api/EventParticipators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<ActionResult<EventParticipator>> PostEventParticipator(EventParticipator eventParticipator)
        {
            _context.EventParticipator.Add(eventParticipator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventParticipator", new { id = eventParticipator.EventParticipatorId }, await CreateView(eventParticipator));
        }

        // DELETE: api/EventParticipators/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<IActionResult> DeleteEventParticipator(int id)
        {
            var eventParticipator = await _context.EventParticipator.FindAsync(id);
            if (eventParticipator == null)
            {
                return NotFound();
            }

            _context.EventParticipator.Remove(eventParticipator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventParticipatorExists(int id)
        {
            return _context.EventParticipator.Any(e => e.EventParticipatorId == id);
        }
    }
}
