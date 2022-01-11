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
    public class PersonalInfosController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public PersonalInfosController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/PersonalInfos
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<PersonalInfoView>>> GetPersonalInfo(int? id)
        {
            List<PersonalInfo> personalInfosList = new();
            List<PersonalInfoView> personalInfoViews = new();
            if(id != null)
            {
                var personalInfo = await _context.PersonalInfo.FindAsync(id);

                if (personalInfo == null)
                {
                    return NotFound();
                }
                personalInfoViews.Add(new PersonalInfoView(personalInfo));

                return personalInfoViews;
            }
            if(id == null)
            {
                personalInfosList = await _context.PersonalInfo.ToListAsync();
            }

            if(personalInfosList.Count == 0)
            {
                return NotFound();
            }

            foreach(var personalInfo in personalInfosList)
            {
                personalInfoViews.Add(new PersonalInfoView(personalInfo));
            }

            return personalInfoViews;
        }

        // PUT: api/PersonalInfos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalInfo(int id, PersonalInfo personalInfo)
        {
            if (id != personalInfo.PersonalInfoId)
            {
                return BadRequest();
            }

            _context.Entry(personalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(id))
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

        // POST: api/PersonalInfos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<ActionResult<PersonalInfo>> PostPersonalInfo(PersonalInfo personalInfo)
        {
            _context.PersonalInfo.Add(personalInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalInfo", new { id = personalInfo.PersonalInfoId }, personalInfo);
        }

        // DELETE: api/PersonalInfos/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<IActionResult> DeletePersonalInfo(int id)
        {
            var personalInfo = await _context.PersonalInfo.FindAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            _context.PersonalInfo.Remove(personalInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalInfoExists(int id)
        {
            return _context.PersonalInfo.Any(e => e.PersonalInfoId == id);
        }
    }
}
