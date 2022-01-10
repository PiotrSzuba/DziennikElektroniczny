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
    public class PeopleController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public PeopleController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonView>>> GetPerson()
        {
            return await _context.Person.Select(x => new PersonView(x)).ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonView>> GetPerson(int id)
        {
            var person = await _context.Person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return new PersonView(person);
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            var toMsgs = await _context.Message.Where(x => x.ToPersonId == id).ToListAsync();
            var fromMsgs = await _context.Message.Where(x => x.FromPersonId == id).ToListAsync();

            foreach(var msg in toMsgs)
            {
                msg.ToPersonId = null;
                if(msg.FromPersonId == null)
                {
                    _context.Remove(msg);
                }        
            }

            foreach (var msg in fromMsgs)
            {
                msg.FromPersonId = null;
                if (msg.ToPersonId == null)
                {
                    _context.Remove(msg);
                }
            }

            var studGrades = await _context.Grade.Where(x => x.StudentPersonId == id).ToListAsync();
            var teacherGrades = await _context.Grade.Where(x => x.TeacherPersonId == id).ToListAsync();

            foreach(var grade in studGrades)
            {
                _context.Grade.Remove(grade);
            }

            foreach(var grade in  teacherGrades)
            {
                grade.TeacherPersonId = null;
            }

            await _context.StudentsGroup.Where(x => x.TeacherPersonId == id).ForEachAsync(x => x.TeacherPersonId = null);

            var attendanceStudent = await _context.Attendance.Where(x => x.StudentPersonId == id).ToListAsync();
            foreach(var attendance in attendanceStudent)
            {
                _context.Attendance.Remove(attendance);
            }

            var studNotes = await _context.Note.Where(x => x.StudentPersonId == id).ToListAsync();
            var teacherNotes = await _context.Note.Where(x => x.TeacherPersonId==id).ToListAsync();

            foreach(var note in studNotes)
            {
                _context.Note.Remove(note);
            }
            foreach(var note in teacherNotes)
            {
                note.TeacherPersonId = null;
            }

            var parents = await _context.Parent.Where(x => x.ParentPersonId == id).ToArrayAsync();
            var parentsStud = await _context.Parent.Where(x => x.StudentPersonId == id).ToListAsync();
            foreach(var parent in parents)
            {
                _context.Parent.Remove(parent);
            }
            foreach (var parent in parentsStud)
            {
                _context.Parent.Remove(parent);
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }
    }
}
