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

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;
        private readonly ILogger _logger;

        public LessonsController(DziennikElektronicznyContext context, ILogger<ParentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<LessonView> CreateLessonView(Lesson lesson)
        {
            var teacher = await _context.Person.FindAsync(lesson.TeacherPersonId);
            var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);

            var subject = await _context.Subject.FindAsync(lesson.SubjectId);
            var subjectInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);

            return new LessonView(lesson, subjectInfo, teacherInfo);
        }

        // GET: api/Lessons/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonView>>> GetLesson(
            int? id, int? teacherId, int? subjectId, string teachername, string subjectName, string topic)
        {
            List<LessonView> lessonViews = new();
            List<Lesson> lessonsList = new();
            if (id != null)
            {
                var lesson = await _context.Lesson.FindAsync(id);

                if (lesson == null)
                {
                    return NotFound();
                }
                lessonViews.Add(await CreateLessonView(lesson));
                
                return lessonViews;
            }
            if(teacherId != null)
            {
                if(lessonsList.Count == 0)
                {
                    lessonsList = await _context.Lesson.Where(x => x.TeacherPersonId == teacherId).ToListAsync();
                }
                else
                {
                    lessonsList = await Task.FromResult(lessonsList.Where(x => x.TeacherPersonId == teacherId).ToList());
                }
            }
            if(subjectId != null)
            {
                if(lessonsList.Count == 0)
                {
                    lessonsList = await _context.Lesson.Where(x => x.SubjectId == subjectId).ToListAsync();
                }
                else
                {
                    lessonsList = await Task.FromResult(lessonsList.Where(x => x.SubjectId == subjectId).ToList());
                }
            }
            if(teachername != null)
            {
                List<Lesson> lessons = new();
                if (lessonsList.Count == 0)
                {
                    lessons = await _context.Lesson.ToListAsync();
                }
                foreach (var lesson in lessonsList)
                {
                    var teacher = await _context.Person.FindAsync(lesson.TeacherPersonId);
                    var teacherInfo = await _context.PersonalInfo.FindAsync(teacher.PersonalInfoId);
                    var name = teacherInfo.Name + " " + teacherInfo.Surname;
                    if (name.ToLower().Contains(teachername.ToLower()))
                    {
                        lessons.Add(lesson);
                    }
                }
                lessonsList = lessons;
            }
            if(subjectName != null)
            {
                List<Lesson> lessons = new();
                if (lessonsList.Count == 0)
                {
                    lessonsList = await _context.Lesson.ToListAsync();
                }
                foreach (var lesson in lessonsList)
                {
                    var subject = await _context.Subject.FindAsync(lesson.SubjectId);
                    var subjectInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);
                    if (subjectInfo.Title.ToLower().Contains(subjectName.ToLower()))
                    {
                        lessons.Add(lesson);
                    }
                }
                lessonsList = lessons;
            }
            if(topic != null)
            {
                if (lessonsList.Count == 0)
                {
                    lessonsList = await _context.Lesson.Where(x => x.Topic.ToLower().Contains(topic)).ToListAsync();
                }
                else
                {
                    lessonsList = await Task.FromResult(lessonsList.Where(x => x.Topic.ToLower().Contains(topic.ToLower())).ToList());
                }
            }
            if(id == null && teacherId == null && subjectId == null && teachername == null && subjectName == null && topic == null)
            {
                lessonsList = await _context.Lesson.ToListAsync();
            }
            if (lessonsList.Count == 0)
            {
                return NotFound();
            }
            foreach (var lesson in lessonsList)
            {
                lessonViews.Add(await CreateLessonView(lesson));
            }
            return lessonViews;
        }

        // PUT: api/Lessons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(int id, Lesson lesson)
        {
            if (id != lesson.LessonId)
            {
                return BadRequest();
            }

            _context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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

        // POST: api/Lessons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lesson>> PostLesson(Lesson lesson)
        {
            _context.Lesson.Add(lesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLesson", new { id = lesson.LessonId }, lesson);
        }

        // DELETE: api/Lessons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lesson.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.LessonId == id);
        }
    }
}
