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
    public class ParentsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;
        private readonly ILogger _logger;

        public ParentsController(DziennikElektronicznyContext context, ILogger<ParentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ParentView> CreateView(Parent parent)
        {
            var parentPerson = await _context.Person.FindAsync(parent.ParentPersonId);
            var parentInfo = await _context.PersonalInfo.FindAsync(parentPerson.PersonalInfoId);

            var studentPerson = await _context.Person.FindAsync(parent.StudentPersonId);
            var studentInfo = await _context.PersonalInfo.FindAsync(studentPerson.PersonalInfoId);

            return new ParentView(parent,parentInfo,studentInfo);
        }

        // GET: api/Parents
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 2 })]
        public async Task<ActionResult<IEnumerable<ParentView>>> GetParent(
            int? id,int? parentId,int? studentId,string parentName, string studentName)
        {
            List<Parent> parentsList = new();
            List<ParentView> parentViews = new();
            if(id != null)
            {
                var parent = await _context.Parent.FindAsync(id);

                if (parent == null)
                {
                    return NotFound();
                }
                parentViews.Add(await CreateView(parent));

                return parentViews;
            }
            if(parentId != null)
            {
                if(parentsList.Count == 0)
                {
                    parentsList = await _context.Parent
                        .Where(x => x.ParentPersonId == parentId)
                        .ToListAsync();
                }
                else
                {
                    parentsList = await Task.FromResult(parentsList
                        .Where(x => x.ParentPersonId == parentId)
                        .ToList());
                }
            }
            if (studentId != null)
            {
                if (parentsList.Count == 0)
                {
                    parentsList = await _context.Parent
                        .Where(x => x.StudentPersonId == studentId)
                        .ToListAsync();
                }
                else
                {
                    parentsList = await Task.FromResult(parentsList
                        .Where(x => x.StudentPersonId == studentId)
                        .ToList());
                }
            }
            if(parentName != null)
            {
                List<Parent> parents = new List<Parent>();
                if(parentsList.Count == 0)
                {
                    parentsList = await _context.Parent.ToListAsync();
                }
                foreach(var parent in parentsList)
                {
                    var parentPerson = await _context.Person.FindAsync(parent.ParentPersonId);
                    var parentInfo = await _context.PersonalInfo.FindAsync(parentPerson.PersonalInfoId);
                    var name = parentInfo.Name + " " + parentInfo.Surname;
                    if(name.ToLower().Contains(parentName.ToLower()))
                    {
                        parents.Add(parent);
                    }
                }
                parentsList = parents;
            }
            if(studentName != null)
            {
                if (parentName != null)
                {
                    List<Parent> parents = new List<Parent>();
                    if (parentsList.Count == 0)
                    {
                        parentsList = await _context.Parent.ToListAsync();
                    }
                    foreach (var parent in parentsList)
                    {
                        var studentPerson = await _context.Person.FindAsync(parent.ParentPersonId);
                        var studentInfo = await _context.PersonalInfo.FindAsync(studentPerson.PersonalInfoId);
                        var name = studentInfo.Name + " " + studentInfo.Surname;
                        if (name.ToLower().Contains(studentName.ToLower()))
                        {
                            parents.Add(parent);
                        }
                    }
                    parentsList = parents;
                }
            }
            if(id == null && parentId == null && studentId == null && parentName == null && studentName == null)
            {
                parentsList = await _context.Parent.ToListAsync();
            }

            if (parentsList.Count == 0)
            {
                return NotFound();
            }

            foreach(var parent in parentsList)
            {
                parentViews.Add(await CreateView(parent));
            }

            return parentViews;
        }

        // PUT: api/Parents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<IActionResult> PutParent(int id, Parent parent)
        {
            if (id != parent.ParentId)
            {
                return BadRequest();
            }

            _context.Entry(parent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentExists(id))
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

        // POST: api/Parents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<ActionResult<Parent>> PostParent(Parent parent)
        {
            _context.Parent.Add(parent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParent", new { id = parent.ParentId }, await CreateView(parent));
        }

        // DELETE: api/Parents/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parent = await _context.Parent.FindAsync(id);
            if (parent == null)
            {
                return NotFound();
            }

            _context.Parent.Remove(parent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentExists(int id)
        {
            return _context.Parent.Any(e => e.ParentId == id);
        }
    }
}
