using Alorotbe.Persistence;
using AlorotbeApi;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Alorotbe.Api.Common
{
    [ApiController]
    [EnableCors(Startup.AllowAny)]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected int? UserId {
            get 
            {
                if (int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, out int userId)) 
                {
                    return userId;
                }

                return null;
            }
        }

        protected int? StudentId
        {
            get
            {
                if (UserId is null) return null;
                var student = _context.Students.FirstOrDefault(s => s.UserId == UserId);

                if (student is null)
                    return null;

                return student.StudentId;
            }
        }
    }
}
