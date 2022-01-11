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

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public SubjectsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        public async Task<SubjectView> CreateSubjectView(Subject subject)
        {
            var teacher = await _context.Person.FindAsync(subject.TeacherPersonId);
            var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);
            var classRoom = await _context.ClassRoom.FindAsync(subject.ClassRoomId);
            var subjectInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);
            var studentsGroup = await _context.StudentsGroup.FindAsync(subject.StudentsGroupId);

            return new SubjectView(subject, subjectInfo, classRoom, studentsGroup, teacherInfo);
        }

        //// GET: api/Subjects
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<SubjectView>>> GetSubject(
            int? id, int? teacherId, int? classRoomId,int? studentsGroupId,string classroomName,
            string classroomFloor, string classroomBuilding, string subjectName)
        {
            List<SubjectView> subjectViews = new();
            List<Subject> subjectsList = new();
            if (id != null)
            {
                var subject = await _context.Subject.FindAsync(id);
                if (subject == null)
                {
                    return NotFound();
                }
                subjectViews.Add(await CreateSubjectView(subject));

                return subjectViews;
            }
            if(teacherId != null)
            {
                if(subjectsList.Count == 0)
                {
                    subjectsList = await _context.Subject
                        .Where(x => x.TeacherPersonId == teacherId)
                        .ToListAsync();
                }
                else
                {
                    subjectsList = await Task.FromResult(subjectsList
                        .Where(x => x.TeacherPersonId == teacherId)
                        .ToList());
                }
            }
            if(studentsGroupId != null)
            {
                if(subjectsList.Count == 0)
                {
                    subjectsList = await _context.Subject.Where(x => x.StudentsGroupId == studentsGroupId).ToListAsync();
                }
                else
                {
                    subjectsList = await Task.FromResult(subjectsList
                        .Where(x => x.StudentsGroupId == studentsGroupId)
                        .ToList());
                }
            }
            if(classRoomId != null)
            {
                if (subjectsList.Count == 0)
                {
                    subjectsList = await _context.Subject
                        .Where(x => x.ClassRoomId == classRoomId)
                        .ToListAsync();
                }
                else
                {
                    subjectsList = await Task.FromResult(subjectsList
                        .Where(x => x.ClassRoomId == classRoomId)
                        .ToList());
                }
            }
            if(classroomName != null)
            {
                List<Subject> subjects = new();
                if(subjectsList.Count == 0)
                {
                    subjectsList = await _context.Subject.ToListAsync();
                }

                foreach(var subject in subjectsList)
                {
                    var classRoom = await _context.ClassRoom.FindAsync(subject.ClassRoomId);
                    if(classRoom.Destination.ToLower().Contains(classroomName.ToLower()))
                    {
                        subjects.Add(subject);
                    }
                }
                subjectsList = subjects;
            }
            if(classroomFloor != null)
            {
                List<Subject> subjects = new();
                if (subjectsList.Count == 0)
                {
                    subjectsList = await _context.Subject.ToListAsync();
                }

                foreach (var subject in subjectsList)
                {
                    var classRoom = await _context.ClassRoom.FindAsync(subject.ClassRoomId);
                    if (classRoom.Floor.ToLower().Contains(classroomFloor.ToLower()))
                    {
                        subjects.Add(subject);
                    }
                }
                subjectsList = subjects;
            }
            if(classroomBuilding != null)
            {
                List<Subject> subjects = new();
                if (subjectsList.Count == 0)
                {
                    subjectsList = await _context.Subject.ToListAsync();
                }

                foreach (var subject in subjectsList)
                {
                    var classRoom = await _context.ClassRoom.FindAsync(subject.ClassRoomId);
                    if (classRoom.Building.ToLower().Contains(classroomBuilding.ToLower()))
                    {
                        subjects.Add(subject);
                    }
                }
                subjectsList = subjects;
            }
            if (subjectName != null)
            {
                List<Subject> subjects = new();

                if(subjectsList.Count == 0)
                {
                    subjectsList = await _context.Subject.ToListAsync();
                }

                foreach (var subject in subjectsList)
                {
                    var subjectsInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);

                    if(subjectsInfo.Title.ToLower().Contains(subjectName.ToLower()))
                    {
                        subjects.Add(subject);
                    }
                }
                subjectsList = subjects;
            }
            if (id == null && subjectName == null && teacherId == null 
                && studentsGroupId == null && classRoomId == null && classroomName == null &&
                classroomFloor == null && classroomBuilding == null)
            {
                subjectsList = await _context.Subject.ToListAsync();
            }
            if (subjectsList.Count == 0)
            {
                return NotFound();
            }
            foreach (var subject in subjectsList)
            {
                subjectViews.Add(await CreateSubjectView(subject));
            }

            return subjectViews;
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            _context.Subject.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubject", new { id = subject.SubjectId }, await CreateSubjectView(subject));
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.SubjectId == id);
        }
    }
}
