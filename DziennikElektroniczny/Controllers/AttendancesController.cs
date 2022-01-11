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
    public class AttendancesController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public AttendancesController(DziennikElektronicznyContext context)
        {
            _context = context;
        }
        public async Task<AttendanceView> CreateAttendanceView(Attendance attendance)
        {
            var student = await _context.Person.FindAsync(attendance.StudentPersonId);
            var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);

            var lesson = await _context.Lesson.FindAsync(attendance.LessonId);

            var subject = await _context.Subject.FindAsync(lesson.SubjectId);
            var subjectInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);

            return new AttendanceView(attendance, studentInfo,lesson,subjectInfo);
        }

        // GET: api/Attendances
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<AttendanceView>>> GetAttendance(
            int? id,int? studentId,int? lessonId,int? wasPresent,string subjectName = null
            ,string studentName = null)
        {
            List<Attendance> attendancesList = new();
            List<AttendanceView> attendanceViews = new();
            if (id != null)
            {
                var attendance = await _context.Attendance.FindAsync(id);

                if (attendance == null)
                {
                    return NotFound();
                }

                attendanceViews.Add(await CreateAttendanceView(attendance));

                return attendanceViews;
            }
            if(studentId != null)
            {
                if(attendancesList.Count == 0)
                {
                    attendancesList = await _context.Attendance
                        .Where(x => x.StudentPersonId == studentId)
                        .ToListAsync();
                }
                else
                {
                    attendancesList = await Task.FromResult(attendancesList
                        .Where(x => x.StudentPersonId == studentId)
                        .ToList());
                }
            }
            if(lessonId != null)
            {
                if(attendancesList.Count == 0)
                {
                    attendancesList = await _context.Attendance
                        .Where(x => x.LessonId == lessonId)
                        .ToListAsync();
                }
                else
                {
                    attendancesList = await Task.FromResult(attendancesList
                        .Where(x => x.LessonId == lessonId)
                        .ToList());
                }
            }
            if(wasPresent != null)
            {
                if (attendancesList.Count == 0)
                {
                    attendancesList = await _context.Attendance
                        .Where(x => x.WasPresent == wasPresent)
                        .ToListAsync();
                }
                else
                {
                    attendancesList = await Task.FromResult(attendancesList
                        .Where(x => x.WasPresent == wasPresent)
                        .ToList());
                }
            }
            if(subjectName != null)
            {
                List<Attendance> attendances = new();
                if(attendancesList.Count == 0)
                {
                    attendancesList = await _context.Attendance.ToListAsync();
                }
                foreach(var attendance in attendancesList)
                {
                    var lesson = await _context.Lesson.FindAsync(attendance.LessonId);
                    var subject = await _context.Subject.FindAsync(lesson.SubjectId);
                    var subjectInfo = await _context.SubjectInfo.FindAsync(subject.SubjectInfoId);
                    if (subjectInfo.Title.ToLower().Contains(subjectName.ToLower()))
                    {
                        attendances.Add(attendance);
                    }
                }
                attendancesList = attendances;
            }
            if(studentName != null)
            {
                List<Attendance> attendances = new();
                if (attendancesList.Count == 0)
                {
                    attendancesList = await _context.Attendance.ToListAsync();
                }
                foreach (var attendance in attendancesList)
                {
                    var student = await _context.Person.FindAsync(attendance.StudentPersonId);
                    var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);
                    var name = studentInfo.Name + " " + studentInfo.Surname;
                    if (name.ToLower().Contains(studentName.ToLower()))
                    {
                        attendances.Add(attendance);
                    }
                }
                attendancesList = attendances;
            }
            if(id == null && studentId == null && lessonId == null 
                && wasPresent == null && subjectName == null && studentName == null)
            {
                attendancesList = await _context.Attendance.ToListAsync();
            }
            if (attendancesList.Count == 0)
            {
                return NotFound();
            }
            foreach (var attendance in attendancesList)
            {
                attendanceViews.Add(await CreateAttendanceView(attendance));
            }

            return attendanceViews;
        }

        // PUT: api/Attendances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 2 })]
        public async Task<IActionResult> PutAttendance(int id, Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(attendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(id))
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

        // POST: api/Attendances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {
            _context.Attendance.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendance", new { id = attendance.AttendanceId }, await CreateAttendanceView(attendance));
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 3 })]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.Attendance.Remove(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendance.Any(e => e.AttendanceId == id);
        }
    }
}
