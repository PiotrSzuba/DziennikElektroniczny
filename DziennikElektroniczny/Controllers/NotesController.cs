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
    public class NotesController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public NotesController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        public Tuple<PersonalInfo,PersonalInfo> GetStudTeacherInfos(Note note)
        {
            var teacher = _context.Person.Find(note.TeacherPersonId);
            var teacherInfo =  _context.PersonalInfo.Find(teacher.PersonalInfoId);

            var student = _context.Person.Find(note.StudentPersonId);
            var studentInfo =  _context.PersonalInfo.Find(student.PersonalInfoId);

            return new Tuple<PersonalInfo, PersonalInfo>(studentInfo, teacherInfo);
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteView>>> GetNote()
        {
            var notes = await _context.Note.ToListAsync();
            List<NoteView> notesList = new();
            foreach(var note in notes)
            {
                var type = GetStudTeacherInfos(note);
                notesList.Add(new NoteView(note, type.Item1, type.Item2));
            }
            return notesList;
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteView>> GetNote(int id)
        {
            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            var type = GetStudTeacherInfos(note);

            return new NoteView(note,type.Item1, type.Item2);
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Note.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.NoteId }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
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
