using FilmsLibraryBLL.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilmsLibraryBLL.Services
{
    public class TokenProvider : ITokenProvider
    {
        public string GenerateToken(int userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myIssuerSigningKeyqwerty123myIssuerSigningKeyqwerty123myIssuerSigningKeyqwerty123"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            };
            var token = new JwtSecurityToken(issuer: "myIssuer",
                audience: "myAudience", claims: claims,
                expires: DateTime.UtcNow.AddHours(1), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
