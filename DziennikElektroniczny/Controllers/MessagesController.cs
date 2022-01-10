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
    public class MessagesController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public MessagesController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        public async Task<MessageView> CreateView(Message message)
        {
            var fromPerson = await _context.Person.FindAsync(message.FromPersonId);
            var fromPrsonInfo = await _context.PersonalInfo.FindAsync(fromPerson.PersonalInfoId);

            var toPerson = await _context.Person.FindAsync(message.ToPersonId);
            var toPersonInfo = await _context.PersonalInfo.FindAsync(toPerson.PersonalInfoId);

            var messageContent = await _context.MessageContent.FindAsync(message.MessageContentId);

            return new MessageView(message,messageContent,fromPrsonInfo,toPersonInfo);
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageView>>> GetMessage(int? id)
        {
            List<Message> messagesList = new();
            List<MessageView> messageViews = new();
            if(id != null)
            {
                var message = await _context.Message.FindAsync(id);

                if (message == null)
                {
                    return NotFound();
                }

                messageViews.Add(await CreateView(message));

                return messageViews;
            }
            if(id == null)
            {
                messagesList = await _context.Message.ToListAsync();
            }
            if(messagesList.Count == 0)
            {
                return NotFound();
            }

            foreach(var message in messagesList)
            {
                messageViews.Add(await CreateView(message));
            }

            return messageViews;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.MessageId }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Message.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return _context.Message.Any(e => e.MessageId == id);
        }
    }
}
