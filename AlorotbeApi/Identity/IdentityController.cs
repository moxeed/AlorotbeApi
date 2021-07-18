using Alorotbe.Api.Common;
using Alorotbe.Api.Identity.Models;
using Alorotbe.Api.Services;
using Alorotbe.Persistence;
using Core.Identity;
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
                                  ApplicationDbContext context)
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
            await _context.SaveChangesAsync();

            return Ok(user.Id);
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

            return BadRequest("Invalid Username Or Password");
        }

        [HttpGet]
        public async Task<IActionResult> Supporter()
        {
            var supporters = await _context.Supporters.ToListAsync();
            return Ok(supporters.Select(s => new SupporterModel
            {
                SupporterId = s.SupporterId,
                Name = s.Name,
                LastName = s.LastName
            }));
        }
    }
}
