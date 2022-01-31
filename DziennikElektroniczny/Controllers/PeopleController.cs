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
using Microsoft.Extensions.Logging;
using DziennikElektroniczny.Utils;
using Microsoft.Extensions.Primitives;
using DziennikElektroniczny.Services;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;
        private readonly ILogger _logger;
        private readonly AuthService _authService;
        public PeopleController(DziennikElektronicznyContext context, ILogger<ParentsController> logger, AuthService authService)
        {
            _context = context;
            _logger = logger;
            _authService = authService;
        }

        private async Task<PersonView> CreateView(Person person)
        {

            return new PersonView(person, await GetPersonalInfo(person));
        }
        public async Task<PersonalInfo> GetPersonalInfo(Person person)
        {
            return await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
        }

        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        [HttpPost("ChangePassword")]
        public ActionResult<bool> ChangePassword(ChangePasswordRequest req)
        {
            StringValues token;
            Request.Headers.TryGetValue("JWT", out token);
            Person p = _authService.GetPersonFromJWT(token);
            if (p != null)
            {
                p.HashedPassword = Hasher.hashEncoder(req.newPassword);
                this._context.Person.Update(p);
                this._context.SaveChanges();
                
                return true;
            }
            return false;
        }

        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        [HttpOptions]
        public async Task<ActionResult> GetCurrentLoggedPerson()
        {
            StringValues token;
            Request.Headers.TryGetValue("JWT", out token);
            Person p = _authService.GetPersonFromJWT(token);
            PersonView pv = await CreateView(p);
            return new JsonResult(pv);
        }

        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonView>>> GetPerson(
            int? id, int? role, string login, string name, string secondname, string surname, string phonenumber, string address, string pesel)
        {
            List<Person> personsList = new();
            List<PersonView> personViews = new();
            if (id != null)
            {
                var person = await _context.Person.FindAsync(id);

                if (person == null)
                {
                    return NotFound();
                }

                personViews.Add(await CreateView(person));
                return personViews;
            }
            if (role != null)
            {
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person.Where(x => x.Role == role).ToListAsync();
                }
                else
                {
                    personsList = await Task.FromResult(personsList.Where(x => x.Role == role).ToList());
                }
            }
            if (login != null)
            {
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person
                        .Where(x => x.Login.ToLower().Contains(login.ToLower()))
                        .ToListAsync();
                }
                else
                {
                    personsList = await Task.FromResult(personsList
                        .Where(x => x.Login.ToLower().Contains(login.ToLower()))
                        .ToList());
                }
            }
            if (name != null)
            {
                List<Person> persons = new();
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person.ToListAsync();
                }
                foreach (var person in personsList)
                {
                    var personalInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
                    if (personalInfo.Name.ToLower().Contains(name.ToLower()))
                    {
                        persons.Add(person);
                    }
                }
                personsList = persons;
            }
            if (secondname != null)
            {
                List<Person> persons = new();
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person.ToListAsync();
                }
                foreach (var person in personsList)
                {
                    var personalInfo = await GetPersonalInfo(person);
                    if (personalInfo.SecondName.ToLower().Contains(surname.ToLower()))
                    {
                        persons.Add(person);
                    }
                }
                personsList = persons;
            }
            if (surname != null)
            {
                List<Person> persons = new();
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person.ToListAsync();
                }
                foreach (var person in personsList)
                {
                    var personalInfo = await GetPersonalInfo(person);
                    if (personalInfo.Surname.ToLower().Contains(surname.ToLower()))
                    {
                        persons.Add(person);
                    }
                }
                personsList = persons;
            }
            if (phonenumber != null)
            {
                List<Person> persons = new();
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person.ToListAsync();
                }
                foreach (var person in personsList)
                {
                    var personalInfo = await GetPersonalInfo(person);
                    if (personalInfo.PhoneNumber.ToLower().Contains(phonenumber.ToLower()))
                    {
                        persons.Add(person);
                    }
                }
                personsList = persons;
            }
            if (address != null)
            {
                List<Person> persons = new();
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person.ToListAsync();
                }
                foreach (var person in personsList)
                {
                    var personalInfo = await GetPersonalInfo(person);
                    if (personalInfo.Address.ToLower().Contains(address.ToLower()))
                    {
                        persons.Add(person);
                    }
                }
                personsList = persons;
            }
            if (pesel != null)
            {
                List<Person> persons = new();
                if (personsList.Count == 0)
                {
                    personsList = await _context.Person.ToListAsync();
                }
                foreach (var person in personsList)
                {
                    var personalInfo = await GetPersonalInfo(person);
                    if (personalInfo.Pesel.ToLower().Contains(pesel.ToLower()))
                    {
                        persons.Add(person);
                    }
                }
                personsList = persons;
            }
            if (id == null && role == null && login == null && name == null
                && secondname == null && surname == null && phonenumber == null
                && address == null && pesel == null)
            {
                personsList = await _context.Person.ToListAsync();
            }
            if (personsList.Count == 0)
            {
                return NotFound();
            }

            foreach (var person in personsList)
            {
                personViews.Add(await CreateView(person));
            }

            return personViews;
        }

        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
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
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            person.HashedPassword = Hasher.hashEncoder(person.HashedPassword);
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, await CreateView(person));
        }

        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
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

            foreach (var msg in toMsgs)
            {
                msg.ToPersonId = null;
                if (msg.FromPersonId == null)
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

            foreach (var grade in studGrades)
            {
                _context.Grade.Remove(grade);
            }

            foreach (var grade in teacherGrades)
            {
                grade.TeacherPersonId = null;
            }

            await _context.StudentsGroup.Where(x => x.TeacherPersonId == id).ForEachAsync(x => x.TeacherPersonId = null);

            var attendanceStudent = await _context.Attendance.Where(x => x.StudentPersonId == id).ToListAsync();
            foreach (var attendance in attendanceStudent)
            {
                _context.Attendance.Remove(attendance);
            }

            var studNotes = await _context.Note.Where(x => x.StudentPersonId == id).ToListAsync();
            var teacherNotes = await _context.Note.Where(x => x.TeacherPersonId == id).ToListAsync();

            foreach (var note in studNotes)
            {
                _context.Note.Remove(note);
            }
            foreach (var note in teacherNotes)
            {
                note.TeacherPersonId = null;
            }

            var parents = await _context.Parent.Where(x => x.ParentPersonId == id).ToArrayAsync();
            var parentsStud = await _context.Parent.Where(x => x.StudentPersonId == id).ToListAsync();
            foreach (var parent in parents)
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
    public class ChangePasswordRequest
    {
        public string newPassword { get; set; }
    }
}

