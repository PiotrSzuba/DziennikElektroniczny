using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DziennikElektroniczny.Data;
using DziennikElektroniczny.Models;

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

        // GET: api/StudentsGroupMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsGroupMember>>> GetStudentsGroupMember()
        {
            return await _context.StudentsGroupMember.ToListAsync();
        }

        // GET: api/StudentsGroupMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsGroupMember>> GetStudentsGroupMember(int id)
        {
            var studentsGroupMember = await _context.StudentsGroupMember.FindAsync(id);

            if (studentsGroupMember == null)
            {
                return NotFound();
            }

            return studentsGroupMember;
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

            return CreatedAtAction("GetStudentsGroupMember", new { id = studentsGroupMember.StudentsGroupMemberId }, studentsGroupMember);
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
