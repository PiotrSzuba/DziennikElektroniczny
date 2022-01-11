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
    public class StudentsGroupMembersController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public StudentsGroupMembersController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        public async Task<StudentsGroupMemberView> CreateView(StudentsGroupMember studentsMemberGroup)
        {
            var studentsGroup = await _context.StudentsGroup.FindAsync(studentsMemberGroup.StudentsGroupId);

            var student = await _context.Person.FindAsync(studentsMemberGroup.StudentPersonId);
            var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);

            return new StudentsGroupMemberView(studentsMemberGroup, studentsGroup, studentInfo);
        }

        // GET: api/StudentsGroupMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsGroupMemberView>>> GetStudentsGroupMember(
            int? id,int? groupId,int? studentId,string groupName,string studentName)
        {
            List<StudentsGroupMember> studentsGroupMembersList = new();
            List<StudentsGroupMemberView> studentsGroupMemberViews = new();
            if(id != null)
            {
                var studentsGroupMember = await _context.StudentsGroupMember.FindAsync(id);

                if (studentsGroupMember == null)
                {
                    return NotFound();
                }

                studentsGroupMemberViews.Add(await CreateView(studentsGroupMember));
                return studentsGroupMemberViews;
            }
            if(groupId != null)
            {
                if(studentsGroupMembersList.Count == 0)
                {
                    studentsGroupMembersList = await _context.StudentsGroupMember.Where(x => x.StudentsGroupId == groupId).ToListAsync();
                }
                else
                {
                    studentsGroupMembersList = await Task.FromResult(studentsGroupMembersList.Where(x => x.StudentsGroupId == groupId).ToList());
                }
            }
            if(studentId != null)
            {
                if (studentsGroupMembersList.Count == 0)
                {
                    studentsGroupMembersList = await _context.StudentsGroupMember
                        .Where(x => x.StudentPersonId == studentId)
                        .ToListAsync();
                }
                else
                {
                    studentsGroupMembersList = await Task.FromResult(studentsGroupMembersList
                        .Where(x => x.StudentPersonId == studentId)
                        .ToList());
                }
            }
            if(groupName != null)
            {
                List<StudentsGroupMember> studentsGroupMembers = new();
                if (studentsGroupMembersList.Count == 0)
                {
                    studentsGroupMembersList = await _context.StudentsGroupMember.ToListAsync();
                }
                foreach(var studentMember in studentsGroupMembersList)
                {
                    var studentsGroup = await _context.StudentsGroup.FindAsync(studentMember.StudentsGroupId);
                    if(studentsGroup.Title.ToLower().Contains(groupName.ToLower()))
                    {
                        studentsGroupMembers.Add(studentMember);
                    }
                }
                studentsGroupMembersList = studentsGroupMembers;
            }
            if(studentName != null)
            {
                List<StudentsGroupMember> studentsGroupMembers = new();
                if (studentsGroupMembersList.Count == 0)
                {
                    studentsGroupMembersList = await _context.StudentsGroupMember.ToListAsync();
                }
                foreach (var studentMember in studentsGroupMembersList)
                {
                    var student = await _context.Person.FindAsync(studentMember.StudentPersonId);
                    var studentInfo = await _context.PersonalInfo.FindAsync(student.PersonalInfoId);
                    var name = studentInfo.Name + " " + studentInfo.Surname;
               
                    if (name.ToLower().Contains(studentName.ToLower()))
                    {
                        studentsGroupMembers.Add(studentMember);
                    }
                }
                studentsGroupMembersList = studentsGroupMembers;
            }
            if(id == null && groupId == null && studentId == null && groupName == null && studentName == null)
            {
                studentsGroupMembersList = await _context.StudentsGroupMember.ToListAsync();
            }
            if(studentsGroupMembersList.Count == 0)
            {
                return NotFound();
            }
            foreach(var studentsGroupMember in studentsGroupMembersList)
            {
                studentsGroupMemberViews.Add(await CreateView(studentsGroupMember));
            }

            return studentsGroupMemberViews;
        }

        // PUT: api/StudentsGroupMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsGroupMember(int id, StudentsGroupMember studentsGroupMember)
        {
            if (id != studentsGroupMember.StudentsGroupMemberId)
            {
                return BadRequest();
            }

            _context.Entry(studentsGroupMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsGroupMemberExists(id))
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

        // POST: api/StudentsGroupMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsGroupMember>> PostStudentsGroupMember(StudentsGroupMember studentsGroupMember)
        {
            _context.StudentsGroupMember.Add(studentsGroupMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsGroupMember", new { id = studentsGroupMember.StudentsGroupMemberId }, await CreateView(studentsGroupMember));
        }

        // DELETE: api/StudentsGroupMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsGroupMember(int id)
        {
            var studentsGroupMember = await _context.StudentsGroupMember.FindAsync(id);
            if (studentsGroupMember == null)
            {
                return NotFound();
            }

            _context.StudentsGroupMember.Remove(studentsGroupMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsGroupMemberExists(int id)
        {
            return _context.StudentsGroupMember.Any(e => e.StudentsGroupMemberId == id);
        }
    }
}
