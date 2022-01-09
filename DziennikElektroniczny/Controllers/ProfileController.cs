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
            var parents = _context.Parent.Where(x => x.StudentPersonId == id).Select(x => _context.Person.Find(x.ParentPersonId)).ToList();
            List<PersonalInfo> parentsInfos = new();
            //if (parents != null)
            //{
            //    foreach (var parent in parents)
            //    {
            //        parentsInfos.Add(_context.PersonalInfo.Find(parent.PersonalInfoId));
            //    }
            //}

            return new Profile(personalInfo, parentsInfos);
        }
    }
} 