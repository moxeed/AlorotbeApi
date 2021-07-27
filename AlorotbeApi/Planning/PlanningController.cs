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

        public PlanningController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Submit()
        {
            var isSubmited = await _context.DailyStudies.AnyAsync(d => d.StudeyDate.Date == System.DateTime.Now.Date);
            return Ok(isSubmited);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Submit(DailtyStudyModel model)
        {
            var isSubmited = await _context.DailyStudies.AnyAsync(d => d.StudeyDate.Date == System.DateTime.Now.Date);

            if (isSubmited)
                return BadRequest("گزارش امروز ثبت شده است");

            try {
                var study = model.DailyStudy(StudentId.Value);
                _context.Add(study);

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Top([FromQuery] TopFilterModel model)
        {
            var data = _context.StudentScores.FromSqlRaw("GetTopStudent @p0, @p1, @p2, @p3", model.Period, model.Criterion, model.Count, model.GradeId);
            var scores = await data.ToListAsync();
            return Ok(scores.Select(s => new StudentScoreModel(s)));
        }

        [HttpGet("{count?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Study(int? count) 
        {
            count ??= int.MaxValue;
            var studies = await _context.DailyStudies
                .Include(d => d.CourseStudies)
                .ThenInclude(c => c.Course)
                .Where(d => d.StudentId == StudentId)
                .OrderByDescending(d => d.StudeyDate)
                .Take(count.Value).ToListAsync();

            return Ok(studies.Select(s => new DailtyStudyModel(s)));
        }
    }
}
