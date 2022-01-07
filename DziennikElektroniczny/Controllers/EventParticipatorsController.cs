using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DziennikElektroniczny.Data;
using DziennikElektroniczny.Models;

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

        // GET: api/EventParticipators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventParticipator>>> GetEventParticipator()
        {
            return await _context.EventParticipator.ToListAsync();
        }

        // GET: api/EventParticipators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventParticipator>> GetEventParticipator(int id)
        {
            var eventParticipator = await _context.EventParticipator.FindAsync(id);

            if (eventParticipator == null)
            {
                return NotFound();
            }

            return eventParticipator;
        }

        // PUT: api/EventParticipators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<EventParticipator>> PostEventParticipator(EventParticipator eventParticipator)
        {
            _context.EventParticipator.Add(eventParticipator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventParticipator", new { id = eventParticipator.EventParticipatorId }, eventParticipator);
        }

        // DELETE: api/EventParticipators/5
        [HttpDelete("{id}")]
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
