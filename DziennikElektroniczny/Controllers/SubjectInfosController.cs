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
    public class SubjectInfosController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public SubjectInfosController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/SubjectInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectInfoView>>> GetSubjectInfo()
        {
            return await _context.SubjectInfo.Select(x => new SubjectInfoView(x)).ToListAsync();
        }

        // GET: api/SubjectInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectInfoView>> GetSubjectInfo(int id)
        {
            var subjectInfo = await _context.SubjectInfo.FindAsync(id);

            if (subjectInfo == null)
            {
                return NotFound();
            }

            return new SubjectInfoView(subjectInfo);
        }

        // PUT: api/SubjectInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectInfo(int id, SubjectInfo subjectInfo)
        {
            if (id != subjectInfo.SubjectInfoId)
            {
                return BadRequest();
            }

            _context.Entry(subjectInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectInfoExists(id))
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

        // POST: api/SubjectInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectInfo>> PostSubjectInfo(SubjectInfo subjectInfo)
        {
            _context.SubjectInfo.Add(subjectInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectInfo", new { id = subjectInfo.SubjectInfoId }, subjectInfo);
        }

        // DELETE: api/SubjectInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectInfo(int id)
        {
            var subjectInfo = await _context.SubjectInfo.FindAsync(id);
            if (subjectInfo == null)
            {
                return NotFound();
            }

            _context.SubjectInfo.Remove(subjectInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectInfoExists(int id)
        {
            return _context.SubjectInfo.Any(e => e.SubjectInfoId == id);
        }
    }
}
