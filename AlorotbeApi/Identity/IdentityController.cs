using Alorotbe.Api.Common;
using Alorotbe.Api.Identity.Models;
using Alorotbe.Api.Services;
using Alorotbe.Persistence;
using Core.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Alorotbe.Api.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly JwtTokenManager _tokenManager;

        public IdentityController(SignInManager<User> signInManager,
                                  UserManager<User> userManager,
                                  JwtTokenManager tokenManager,
                                  ApplicationDbContext context) : base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var createdUser = await _userManager.FindByNameAsync(model.UserName);
            var student = model.Student;

            student.SetUserId(createdUser.Id);
            _context.Add(student);
            try{
                await _context.SaveChangesAsync();
            }catch
            {
                _context.Users.Remove(createdUser);
                await _context.SaveChangesAsync();
                return BadRequest("Invalid Student Data");
            }

            var token = _tokenManager.GenerateToken(user);

            return Ok(new LoginResponse(token));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model) 
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is null)
                return BadRequest("Invalid Username Or Password");

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                var token = _tokenManager.GenerateToken(user);
                return Ok(new LoginResponse(token));
            }

            return BadRequest(new ErrorResponse{Error = "Invalid Username Or Password" });
        }

        [HttpGet]
        public async Task<IActionResult> Supporter()
        {
            var supporters = await _context.Supporters.ToListAsync();
            return Ok(supporters.Select(s => new SupporterModel
            {
                SupporterId = s.SupporterId,
                Name = s.Name,
            }));
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UserInfo()
        {
            var student = await _context.Students
                .Include(s => s.User)
                .Include(s => s.Major)
                .Include(s => s.Grade)
                .FirstOrDefaultAsync(s => s.UserId == UserId);

            if (student is null)
               return NotFound();

            return Ok(new UserModel
            {
                UserName = student.User.UserName,
                Name = student.Name,
                LastName = student.LastName,
                PhoneNumber = student.User.PhoneNumber,
                Grade = student.Grade.GradeName,
                Major = student.Major.MajorName
            });
        }
    }
}