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
    public class ClassroomsController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;

        public ClassroomsController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 1 })]
        public async Task<ActionResult<IEnumerable<ClassroomsView>>> GetClassRoom(
            int? id, string classroomName, string classroomFloor, string classroomBuilding)
        {
            List<ClassroomsView> classroomViews = new();
            List<ClassRoom> classroomsList = new();
            if(id != null)
            {
                var classRoom = await _context.ClassRoom.FindAsync(id);

                if (classRoom == null)
                {
                    return NotFound();
                }
                classroomViews.Add(new ClassroomsView(classRoom));
                return classroomViews;
            }
            if (classroomName != null)
            {
                List<ClassRoom> classrooms = new();
                if (classroomsList.Count == 0)
                {
                    classroomsList = await _context.ClassRoom.ToListAsync();
                }

                foreach (var classroom in classroomsList)
                {
                    if (classroom.Destination.ToLower().Contains(classroomName.ToLower()))
                    {
                        classrooms.Add(classroom);
                    }
                }
                classroomsList = classrooms;
            }
            if (classroomFloor != null)
            {
                List<ClassRoom> classrooms = new();
                if (classroomsList.Count == 0)
                {
                    classroomsList = await _context.ClassRoom.ToListAsync();
                }

                foreach (var classroom in classroomsList)
                {
                    if (classroom.Floor.ToLower().Contains(classroomFloor.ToLower()))
                    {
                        classrooms.Add(classroom);
                    }
                }
                classroomsList = classrooms;
            }
            if (classroomBuilding != null)
            {
                List<ClassRoom> classrooms = new();
                if (classroomsList.Count == 0)
                {
                    classroomsList = await _context.ClassRoom.ToListAsync();
                }

                foreach (var classroom in classroomsList)
                {
                    if (classroom.Building.ToLower().Contains(classroomBuilding.ToLower()))
                    {
                        classrooms.Add(classroom);
                    }
                }
                classroomsList = classrooms;
            }
            if(id == null && classroomName == null && classroomFloor == null && classroomBuilding == null)
            {
                classroomsList = await _context.ClassRoom.ToListAsync();
            }

            if (classroomsList.Count == 0)
            {
                return NotFound();
            }

            foreach(var classroom in classroomsList)
            {
                classroomViews.Add(new ClassroomsView(classroom));
            }

            return classroomViews;
        }

        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
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
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
        public async Task<ActionResult<ClassRoom>> PostClassRoom(ClassRoom classRoom)
        {
            _context.ClassRoom.Add(classRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassRoom", new { id = classRoom.ClassRoomId }, classRoom);
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(AuthFilter), Arguments = new object[] { 4 })]
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
