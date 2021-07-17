using Alorotbe.Api.Common;
using Alorotbe.Api.Identity.Models;
using Alorotbe.Persistence;
using Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alorotbe.Api.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public IdentityController(SignInManager<User> signInManager,
                                  UserManager<User> userManager,
                                  ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

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

            return Ok(user);
        }

        public async Task<IActionResult> Login(LoginModel model) 
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is null)
                return BadRequest("Invalid Username Or Password");

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
                return Ok();

            return BadRequest("Invalid Username Or Password");
        }
    }
}
