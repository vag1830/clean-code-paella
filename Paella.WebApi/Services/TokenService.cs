using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Paella.Infrastructure.Entities;

namespace WebApi.Services
{
    public class TokenService
    {
        public JwtSecurityToken CreateToken(PaellaUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asafekeyfromconfiguration"));

            var token = new JwtSecurityToken(
                issuer: "https://paella.com",
                audience: "https://paella.com",
                expires: DateTime.UtcNow.AddMinutes(15),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
