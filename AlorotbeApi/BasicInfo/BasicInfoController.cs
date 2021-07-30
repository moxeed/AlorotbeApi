using Alorotbe.Api.BasicInfo.Models;
using Alorotbe.Api.Common;
using Alorotbe.Core.Identity;
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
            var student = await _context.Students.FirstOrDefaultAsync(s => s.UserId == UserId);

            var courses = _context.Courses.AsQueryable();

            if (student is not null)
                courses = courses.Where(c => c.MajorId == student.MajorId);

            var data = await courses.ToListAsync();
            return Ok(data.Select(c => new ItemModel(c)));
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

        [HttpGet("/Media/{mediaId}")]
        public async Task<IActionResult> Media(int mediaId)
        {
            var media = _context.Set<Media>().FirstOrDefault(m => m.MediaId == mediaId);

            if(media is null)
                return NotFound();

            return File(await System.IO.File.ReadAllBytesAsync(media.FilePath), System.Net.Mime.MediaTypeNames.Image.Jpeg);
        }
    }
}
