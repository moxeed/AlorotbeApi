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

        public BasicInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> City() 
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(cities.Select(c => new ItemModel(c)));
        }

        public async Task<IActionResult> Course() 
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses.Select(c => new ItemModel(c)));
        }

        public async Task<IActionResult> Group() 
        {
            var groups = await _context.Groups.ToListAsync();
            return Ok(groups.Select(g => new ItemModel(g)));
        }
    }
}
