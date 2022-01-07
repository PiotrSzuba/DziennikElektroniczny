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
    public class StudentsGroupsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public StudentsGroupsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/StudentsGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsGroup>>> GetStudentsGroup()
        {
            return await _context.StudentsGroup.ToListAsync();
        }

        // GET: api/StudentsGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsGroup>> GetStudentsGroup(int id)
        {
            var studentsGroup = await _context.StudentsGroup.FindAsync(id);

            if (studentsGroup == null)
            {
                return NotFound();
            }

            return studentsGroup;
        }

        // PUT: api/StudentsGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<StudentsGroup>> PostStudentsGroup(StudentsGroup studentsGroup)
        {
            _context.StudentsGroup.Add(studentsGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsGroup", new { id = studentsGroup.StudentsGroupId }, studentsGroup);
        }

        // DELETE: api/StudentsGroups/5
        [HttpDelete("{id}")]
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
