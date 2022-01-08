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
    public class ClassroomsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public ClassroomsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassroomsView>>> GetClassRoom()
        {
            return await _context.ClassRoom.Select(x => new ClassroomsView(x)).ToArrayAsync();
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomsView>> GetClassRoom(int id)
        {
            var classRoom = await _context.ClassRoom.FindAsync(id);

            if (classRoom == null)
            {
                return NotFound();
            }

            return await Task.FromResult(new ClassroomsView(classRoom));
        }

        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassRoom(int id, ClassRoom classRoom)
        {
            if (id != classRoom.ClassRoomId)
            {
                return BadRequest();
            }

            _context.Entry(classRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassRoomExists(id))
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

        // POST: api/Classrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassRoom>> PostClassRoom(ClassRoom classRoom)
        {
            _context.ClassRoom.Add(classRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassRoom", new { id = classRoom.ClassRoomId }, classRoom);
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassRoom(int id)
        {
            var classRoom = await _context.ClassRoom.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }

            _context.ClassRoom.Remove(classRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassRoomExists(int id)
        {
            return _context.ClassRoom.Any(e => e.ClassRoomId == id);
        }
    }
}
