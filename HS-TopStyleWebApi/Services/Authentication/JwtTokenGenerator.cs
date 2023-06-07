using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HS_TopStyleWebApi.Services.Interfaces;
using HS_TopStyleWebApi.Services.Authentication;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using HS_TopStyleWebApi.Repos.Entities;

namespace HS_TopStyleWebApi.Services.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(User user)
        {
            // generate token that is valid for 7 days

            var signingCredentials = new SigningCredentials(
                               new SymmetricSecurityKey
                               (Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
                               SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
        public string GenerateToken2(User user)
        {
            var newSecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKey123@@444?!MySecretKey"));
            var signingCredentials = new SigningCredentials(newSecretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            var securityToken = new JwtSecurityToken(
                issuer: "https://localhost:5111",
                audience: "https://localhost:5111",
                expires: DateTime.Now.AddMinutes(30),
                claims: claims,
                signingCredentials: signingCredentials);
             
            return new JwtSecurityTokenHandler().WriteToken(securityToken).ToString();
        }
    }
}
