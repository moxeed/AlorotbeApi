using Alorotbe.Api.Common;
using Alorotbe.Api.Planning.Models;
using Alorotbe.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}
