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
    public class GradesController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;
        private readonly ILogger _logger;
        public GradesController(DziennikElektronicznyContext context, ILogger<ParentsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<GradeView> CreateGradeView(Grade grade)
        {
            var student = await _context.Person.FindAsync(grade.StudentPersonId);
            var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);

            var teacher = await _context.Person.FindAsync(grade.TeacherPersonId);
            var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);

            var subject = await _context.Subject.FindAsync(grade.SubjectId);
            var subjectInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);

            return new GradeView(grade, studentInfo,teacherInfo,subjectInfo);
        }

        // GET: api/Grades
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<GradeView>>> GetGrade(
            int? id,int? studentId,int? teacherId,int? subjectId,
            string subjectName,string value, string studentName, string teacherName)
        {
            List<Grade> gradesList = new();
            List<GradeView> gradeViews = new();
            if (id != null)
            {
                var grade = await _context.Grade.FindAsync(id);

                if (grade == null)
                {
                    return NotFound();
                }
                gradeViews.Add(await CreateGradeView(grade));
                return gradeViews;
            }
            if(studentId != null)
            {
                if(gradesList.Count == 0)
                {
                    gradesList = await _context.Grade
                        .Where(x => x.StudentPersonId == studentId)
                        .ToListAsync();
                }
                else
                {
                    gradesList = await Task.FromResult(gradesList
                        .Where(x => x.StudentPersonId == studentId)
                        .ToList());
                }
            }
            if(teacherId != null)
            {
                if(gradesList.Count == 0)
                {
                    gradesList = await _context.Grade
                        .Where(x => x.TeacherPersonId == teacherId)
                        .ToListAsync();
                }
                else
                {
                    gradesList = await Task.FromResult(gradesList
                        .Where(x => x.TeacherPersonId == teacherId)
                        .ToList());
                }
            }
            if(subjectId != null)
            {
                if (subjectId != null)
                {
                    gradesList = await _context.Grade
                        .Where(x => x.SubjectId == subjectId)
                        .ToListAsync();
                }
                else
                {
                    gradesList = await Task.FromResult(gradesList
                        .Where(x => x.SubjectId == subjectId)
                        .ToList());
                }
            }
            if (subjectName != null)
            {
                List<Grade> grades = new();
                if (gradesList.Count == 0)
                {
                    gradesList = await _context.Grade.ToListAsync();
                }
                foreach (var grade in gradesList)
                {
                    var subject = await _context.Subject.FindAsync(grade.SubjectId);
                    var subjectInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);
                    if (subjectInfo.Title.ToLower().Contains(subjectName.ToLower()))
                    {
                        grades.Add(grade);
                    }
                }
                gradesList = grades;
            }
            if(value != null)
            {
                List<Grade> grades = new();
                if (gradesList.Count == 0)
                {
                    gradesList = await _context.Grade.ToListAsync();
                }
                foreach(var grade in gradesList)
                {
                    if (grade.Value.ToLower().Contains(value))
                    {
                        grades.Add(grade);
                    }
                }
                gradesList = grades;
            }
            if (studentName != null)
            {
                List<Grade> grades = new();
                if (gradesList.Count == 0)
                {
                    gradesList = await _context.Grade.ToListAsync();
                }
                foreach (var grade in gradesList)
                {
                    var student = await _context.Person.FindAsync(grade.StudentPersonId);
                    var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);
                    var name = studentInfo.Name + " " + studentInfo.Surname;
                    if (name.ToLower().Contains(studentName))
                    {
                        grades.Add(grade);
                    }
                }
                gradesList = grades;
            }
            if (teacherName != null)
            {
                List<Grade> grades = new();
                if (gradesList.Count == 0)
                {
                    gradesList = await _context.Grade.ToListAsync();
                }
                foreach (var grade in gradesList)
                {
                    var teacher = await _context.Person.FindAsync(grade.StudentPersonId);
                    var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);
                    var name = teacherInfo.Name + " " + teacherInfo.Surname;
                    if (name.ToLower().Contains(teacherName))
                    {
                        grades.Add(grade);
                    }
                }
                gradesList = grades;
            }
            if(id == null && studentId == null && teacherId == null 
                && subjectName == null && subjectId == null && value == null
                && studentName == null  && teacherName == null )
            {
                gradesList = await _context.Grade.ToListAsync();
            }
            if (gradesList.Count == 0)
            {
                return NotFound();
            }
            foreach (var grade in gradesList)
            {
                gradeViews.Add(await CreateGradeView(grade));
            }

            return gradeViews;
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.GradeId)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            _context.Grade.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrade", new { id = grade.GradeId }, await CreateGradeView(grade));
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grade.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.Grade.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeExists(int id)
        {
            return _context.Grade.Any(e => e.GradeId == id);
        }
    }
}
