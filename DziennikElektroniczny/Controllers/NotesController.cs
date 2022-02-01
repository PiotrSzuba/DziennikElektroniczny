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
    public class NotesController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public NotesController(DziennikElektronicznyContext context)
        {
            _context = context;
        }
        
        public async Task<NoteView> CreateView(Note note)
        {
            var teacher = await _context.Person.FindAsync(note.TeacherPersonId);
            var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);

            var student = await _context.Person.FindAsync(note.StudentPersonId);
            var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);

            return new NoteView(note,studentInfo,teacherInfo);
        }

        // GET: api/Notes
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<NoteView>>> GetNote(
            int? id,int? teacherId,string teacherName,int? studentId, string studentName,string description)
        {
            List<Note> notesList = new();
            List<NoteView> noteViews = new();
            if(id != null)
            {
                var note = await _context.Note.FindAsync(id);
                if (note == null)
                {
                    return NotFound();
                }
                noteViews.Add(await CreateView(note));
                return Ok(noteViews);
            }
            if(teacherId != null)
            {
                if(notesList.Count == 0)
                {
                    notesList = await _context.Note
                        .Where(x => x.TeacherPersonId == teacherId)
                        .ToListAsync();
                }
                else
                {
                    notesList = await Task.FromResult(notesList
                        .Where(x => x.TeacherPersonId == teacherId)
                        .ToList());
                }
            }
            if(teacherName != null)
            {
                List<Note> notes = new();
                if(notesList.Count == 0)
                {
                    notesList = await _context.Note.ToListAsync();
                }
                foreach (var note in notesList)
                {
                    var person = await _context.Person.FindAsync(note.TeacherPersonId);
                    var personInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
                    var name = personInfo.Name + " " + personInfo.Surname;
                    if(name.ToLower().Contains(teacherName.ToLower()))
                    {
                        notes.Add(note);
                    }
                }
                notesList = notes;
            }
            if(studentId != null)
            {
                if(notesList.Count == 0)
                {
                    notesList = await _context.Note
                        .Where(x => x.StudentPersonId == studentId)
                        .ToListAsync();
                }
                else
                {
                    notesList = await Task.FromResult(notesList
                        .Where(x => x.StudentPersonId == studentId)
                        .ToList());
                }
            }
            if(studentName != null)
            {
                List<Note> notes = new();
                if (notesList.Count == 0)
                {
                    notesList = await _context.Note.ToListAsync();
                }
                foreach (var note in notesList)
                {
                    var person = await _context.Person.FindAsync(note.StudentPersonId);
                    var personInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
                    var name = personInfo.Name + " " + personInfo.Surname;
                    if (name.ToLower().Contains(studentName.ToLower()))
                    {
                        notes.Add(note);
                    }
                }
                notesList = notes;
            }
            if(description != null)
            {
                if(notesList.Count == 0)
                {
                    notesList = await _context.Note
                        .Where(x => x.Description.ToLower().Contains(description.ToLower()))
                        .ToListAsync();
                }
                else
                {
                    notesList = await Task.FromResult(notesList
                        .Where(x => x.Description.ToLower().Contains(description.ToLower()))
                        .ToList());
                }
            }
            if (id == null && teacherId == null && teacherName == null && studentId == null 
                && studentName == null && description == null)
            {
                notesList = await _context.Note.ToListAsync();
            }

            if(notesList.Count == 0)
            {
                return NotFound();
            }

            foreach(var note in notesList)
            {
                noteViews.Add(await CreateView(note));
            }

            return noteViews;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<IActionResult> PutNote(int id, Note note)
        {
            if (id != note.NoteId)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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

        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Note.Add(note);
            await _context.SaveChangesAsync();

            var student = await _context.Person.FindAsync(note.StudentPersonId);
            var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);
            var teacher = await _context.Person.FindAsync(note.TeacherPersonId);
            var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);

            var messageContent = new MessageContent
            {
                Title = "Uwaga",
                Content = $"Nowa uwaga na koncie ucznia {studentInfo.Name} {studentInfo.Surname} o treści {note.Description} w dniu {note.Date.ToString("MM.dd.yyyy HH:mm")}"
            };

            _context.MessageContent.Add(messageContent);
            await _context.SaveChangesAsync();

            var msgContentList = await _context.MessageContent
                    .Where(x => x.Content.ToLower().Contains($"Nowa uwaga na koncie ucznia {studentInfo.Name} {studentInfo.Surname} o treści {note.Description} w dniu {note.Date.ToString("MM.dd.yyyy HH:mm")}"
                    .ToLower()))
                    .ToListAsync();

            int msgContentID = msgContentList.Max(x => x.MessageContentId);

            var message = new Message
            {
                MessageContentId = msgContentID,
                FromPersonId = note.TeacherPersonId,
                ToPersonId = note.StudentPersonId,
                SendDate = DateTime.Now,
                SeenDate = DateTime.Now
            };
            _context.Message.Add(message);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetNote", new { id = note.NoteId }, await CreateView(note));
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Note.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteExists(int id)
        {
            return _context.Note.Any(e => e.NoteId == id);
        }
    }
}
