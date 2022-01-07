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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly DziennikElektronicznyContext _context;
        public ProfileController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _context.Person.ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetPerson(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            var personalInfo = await _context.PersonalInfo.FindAsync(person.PersonalInfoId);
            if (personalInfo == null)
            {
                return NotFound();
            }
            var parents = await Task.FromResult(_context.Parent.Where(x => x.StudentPersonId == id).ToList());

            return new Profile
            {
                Id = id,
                Name = personalInfo.Name,
                SecondName = personalInfo.SecondName,
                Surname = personalInfo.Surname,
                DateOfBirth = personalInfo.DateOfBirth,
                PhoneNumber = personalInfo.PhoneNumber,
                Address = personalInfo.Address,
                Pesel = personalInfo.Pesel,
                ParentsNames = parents.Select(x => _context.PersonalInfo.FindAsync(x.ParentPersonId).Result.Name).ToList()
            };
        }
    }
} 