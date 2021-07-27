using Alorotbe.Api.BasicInfo.Models;
using Alorotbe.Api.Common;
using Alorotbe.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Alorotbe.Api.BasicInfo
{
    public class BasicInfoController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public BasicInfoController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> City() 
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(cities.Select(c => new ItemModel(c)));
        }

        [HttpGet]
        public async Task<IActionResult> Course() 
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses.Select(c => new ItemModel(c)));
        }

        [HttpGet]
        public async Task<IActionResult> Grade() 
        {
            var groups = await _context.Grades.ToListAsync();
            return Ok(groups.Select(g => new ItemModel(g)));
        }

        [HttpGet]
        public async Task<IActionResult> Major() 
        {
            var groups = await _context.Majors.ToListAsync();
            return Ok(groups.Select(m => new ItemModel(m)));
        }
    }
}
