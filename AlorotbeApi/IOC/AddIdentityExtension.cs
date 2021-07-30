using System.Text;
using Alorotbe.Api.Services;
using Alorotbe.Persistence;
using Core.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Alorotbe.Api.IOC
{
    internal static class AddIdentityExtension
    {
        public static void AddAlorotbeIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.Configure<IdentityOptions>(p => 
            {
               p.Password.RequireDigit = false;
               p.Password.RequireLowercase = false;
               p.Password.RequiredLength = 4;
               p.Password.RequiredUniqueChars = 0;
               p.Password.RequireUppercase = false;
               p.Password.RequireNonAlphanumeric = false;
            });

            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders().AddErrorDescriber<LocalIdentityErrorDescriber>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(configuration["JWTOptions:Secret"]);
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
            });
        }
    }
}