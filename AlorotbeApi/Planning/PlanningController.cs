using Alorotbe.Api.Common;
using Alorotbe.Api.Planning.Models;
using Alorotbe.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Alorotbe.Api.Planning
{
    public class PlanningController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PlanningController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Submit(DailtyStudyModel model)
        {
            var studentId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var study = model.DailyStudy(studentId);
            _context.Add(study);

            try {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch {
                return BadRequest();
            }
        }

        [HttpGet("/[controller]/Top/Test/{count}")]
        public async Task<IActionResult> TopAllByTest(int count)
        {
           var scores = await _context.StudentScoreAlls
                .OrderByDescending(t => t.TotalTestCount)
                .Take(count)
                .ToListAsync();

           return Ok(scores.Select(s => new StudentScoreModel(s)));
        }

        [HttpGet("/[controller]/Top/Time/{count}")]
        public async Task<IActionResult> TopAllByTime(int count)
        {
           var scores = await _context.StudentScoreAlls
                .OrderByDescending(t => t.TotalStudy)
                .Take(count)
                .ToListAsync();

           return Ok(scores.Select(s => new StudentScoreModel(s)));
        }

        [HttpGet("/[controller]/DailyTop/Test/{count}")]
        public async Task<IActionResult> DailyTopAllByTest(int count)
        {
           var scores = await _context.StudentScoreDailies
                .OrderByDescending(t => t.TotalTestCount)
                .Take(count)
                .ToListAsync();

           return Ok(scores.Select(s => new StudentScoreModel(s)));
        }

        [HttpGet("/[controller]/DailyTop/Time/{count}")]
        public async Task<IActionResult> DailyAllByTime(int count)
        {
           var scores = await _context.StudentScoreDailies
                .OrderByDescending(t => t.TotalStudy)
                .Take(count)
                .ToListAsync();

           return Ok(scores.Select(s => new StudentScoreModel(s)));
        }
    }
}
