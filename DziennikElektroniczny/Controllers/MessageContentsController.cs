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
    public class MessageContentsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public MessageContentsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/MessageContents
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<MessageContentView>>> GetMessageContent(
            int? id,string title,string content)
        {
            List<MessageContent> messageContentsList = new();
            List<MessageContentView> messageContentsViews = new();

            if(id != null)
            {
                var messageContent = await _context.MessageContent.FindAsync(id);

                if (messageContent == null)
                {
                    return NotFound();
                }

                messageContentsViews.Add(new MessageContentView(messageContent));

                return messageContentsViews;
            }
            if(title != null)
            {
                if(messageContentsList.Count == 0)
                {
                    messageContentsList = await _context.MessageContent
                        .Where(x => x.Title.ToLower().Contains(title.ToLower()))
                        .ToListAsync();
                }
                else
                {
                    messageContentsList = await Task.FromResult(messageContentsList
                        .Where(x => x.Title.ToLower().Contains(title.ToLower()))
                        .ToList());
                }
            }
            if(content != null)
            {
                if(messageContentsList.Count == 0)
                {
                    messageContentsList = await _context.MessageContent
                        .Where(x => x.Content.ToLower().Contains(content.ToLower()))
                        .ToListAsync();
                }
                else
                {
                    messageContentsList = await Task.FromResult(messageContentsList
                        .Where(x => x.Content.ToLower().Contains(content.ToLower()))
                        .ToList());
                }      
            }
            if (id == null && title == null && content == null)
            {
                messageContentsList = await _context.MessageContent.ToListAsync();
            }
            if(messageContentsList.Count == 0)
            {
                return NotFound();
            }

            foreach (var messageContent in messageContentsList)
            {
                messageContentsViews.Add(new MessageContentView(messageContent));
            }

            return messageContentsViews;
        }

        // PUT: api/MessageContents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
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
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<MessageContent>> PostMessageContent(MessageContent messageContent)
        {
            _context.MessageContent.Add(messageContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageContent", new { id = messageContent.MessageContentId }, messageContent);
        }

        // DELETE: api/MessageContents/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
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
