using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Alorotbe.Api.Services
{
    public class JwtTokenManager
    {
        const string _secret = "JSInid12@8hdnSknicnjsi2@isaxi2O?";
        private readonly UserManager<User> _userManager;

        public JwtTokenManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public string GenerateToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_secret);
            var signInCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var descriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signInCredentials,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }.Concat(GetRoles(user)))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private IEnumerable<Claim> GetRoles(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            return roles.Select(r => new Claim(ClaimTypes.Role, r));
        }
    }
}