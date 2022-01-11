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
    public class StudentsGroupsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public StudentsGroupsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        public async Task<StudentsGroupView> CreateView(StudentsGroup studentsGroup)
        {
            var teacher = await _context.Person.FindAsync(studentsGroup.TeacherPersonId);
            var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);

            var studentsMember = await _context.StudentsGroupMember
                .Where(x => x.StudentsGroupId == studentsGroup.StudentsGroupId)
                .ToListAsync();
            List<PersonalInfo> studentsInfos = new();
            foreach(var studentMember in studentsMember)
            {
                var student = await _context.Person.FindAsync(studentMember.StudentPersonId);
                var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);
                studentsInfos.Add(studentInfo);
            }

            return new StudentsGroupView(studentsGroup,teacherInfo,studentsInfos);
        }

        // GET: api/StudentsGroups
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<StudentsGroupView>>> GetStudentsGroup(
            int? id,int? teacherId,string teacherName,string title,string description,int? yearOfStudy)
        {
            List<StudentsGroup> studentsGroupsList = new();
            List<StudentsGroupView> studentsGroupViews = new();
            if(id != null)
            {
                var studentsGroup = await _context.StudentsGroup.FindAsync(id);

                if (studentsGroup == null)
                {
                    return NotFound();
                }

                studentsGroupViews.Add(await CreateView(studentsGroup));
                return studentsGroupViews;
            }
            if(teacherId != null)
            {
                if(studentsGroupsList.Count == 0)
                {
                    studentsGroupsList = await _context.StudentsGroup.Where(x => x.TeacherPersonId == teacherId).ToListAsync();
                }
                else
                {
                    studentsGroupsList = await Task.FromResult(studentsGroupsList.Where(x => x.TeacherPersonId == teacherId).ToList());
                }
            }
            if(teacherName != null)
            {
                List<StudentsGroup> studentsGroups = new();
                if (studentsGroupsList.Count == 0)
                {
                    studentsGroupsList = await _context.StudentsGroup.ToListAsync();
                }
                foreach (var studentGroup in studentsGroupsList)
                {
                    var teacher = await _context.Person.FindAsync(studentGroup.TeacherPersonId);
                    var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);
                    var name = teacherInfo.Name + " " + teacherInfo.Surname;
                    if(name.ToLower().Contains(teacherName.ToLower()))
                    {
                        studentsGroups.Add(studentGroup);
                    }
                }
                studentsGroupsList = studentsGroups;
            }
            if(title != null)
            {
                if (studentsGroupsList.Count == 0)
                {
                    studentsGroupsList = await _context.StudentsGroup.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToListAsync();
                }
                else
                {
                    studentsGroupsList = await Task.FromResult(studentsGroupsList.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList());
                }
            }
            if(description != null)
            {
                if (studentsGroupsList.Count == 0)
                {
                    studentsGroupsList = await _context.StudentsGroup.Where(x => x.Description.ToLower().Contains(description.ToLower())).ToListAsync();
                }
                else
                {
                    studentsGroupsList = await Task.FromResult(studentsGroupsList.Where(x => x.Description.ToLower().Contains(description.ToLower())).ToList());
                }
            }
            if(yearOfStudy != null)
            {
                if (studentsGroupsList.Count == 0)
                {
                    studentsGroupsList = await _context.StudentsGroup.Where(x => x.YearOfStudy == yearOfStudy).ToListAsync();
                }
                else
                {
                    studentsGroupsList = await Task.FromResult(studentsGroupsList.Where(x => x.YearOfStudy == yearOfStudy).ToList());
                }
            }
            if (id == null && teacherId == null && teacherName == null && title == null && description == null && yearOfStudy == null)
            {
                studentsGroupsList = await _context.StudentsGroup.ToListAsync();
            }
            if(studentsGroupsList.Count == 0)
            {
                return NotFound();
            }
            foreach(var studentGroup in studentsGroupsList)
            {
                studentsGroupViews.Add(await CreateView(studentGroup));
            }

            return studentsGroupViews;
        }

        // PUT: api/StudentsGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<IActionResult> PutStudentsGroup(int id, StudentsGroup studentsGroup)
        {
            if (id != studentsGroup.StudentsGroupId)
            {
                return BadRequest();
            }

            _context.Entry(studentsGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsGroupExists(id))
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

        // POST: api/StudentsGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<ActionResult<StudentsGroup>> PostStudentsGroup(StudentsGroup studentsGroup)
        {
            _context.StudentsGroup.Add(studentsGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsGroup", new { id = studentsGroup.StudentsGroupId }, await CreateView(studentsGroup));
        }

        // DELETE: api/StudentsGroups/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<IActionResult> DeleteStudentsGroup(int id)
        {
            var studentsGroup = await _context.StudentsGroup.FindAsync(id);
            if (studentsGroup == null)
            {
                return NotFound();
            }

            _context.StudentsGroup.Remove(studentsGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsGroupExists(int id)
        {
            return _context.StudentsGroup.Any(e => e.StudentsGroupId == id);
        }
    }
}
