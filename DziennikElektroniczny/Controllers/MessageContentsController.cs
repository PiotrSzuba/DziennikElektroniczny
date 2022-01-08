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
    public class MessageContentsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public MessageContentsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/MessageContents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageContentView>>> GetMessageContent()
        {
            return await _context.MessageContent.Select(x => new MessageContentView(x)).ToListAsync();
        }

        // GET: api/MessageContents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageContentView>> GetMessageContent(int id)
        {
            var messageContent = await _context.MessageContent.FindAsync(id);

            if (messageContent == null)
            {
                return NotFound();
            }

            return new MessageContentView(messageContent);
        }

        // PUT: api/MessageContents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageContent(int id, MessageContent messageContent)
        {
            if (id != messageContent.MessageContentId)
            {
                return BadRequest();
            }

            _context.Entry(messageContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageContentExists(id))
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

        // POST: api/MessageContents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageContent>> PostMessageContent(MessageContent messageContent)
        {
            _context.MessageContent.Add(messageContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageContent", new { id = messageContent.MessageContentId }, messageContent);
        }

        // DELETE: api/MessageContents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageContent(int id)
        {
            var messageContent = await _context.MessageContent.FindAsync(id);
            if (messageContent == null)
            {
                return NotFound();
            }

            _context.MessageContent.Remove(messageContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageContentExists(int id)
        {
            return _context.MessageContent.Any(e => e.MessageContentId == id);
        }
    }
}
