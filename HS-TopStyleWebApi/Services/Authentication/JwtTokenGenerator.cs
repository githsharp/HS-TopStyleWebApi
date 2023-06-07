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
                // new claim for email
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                // new claim for username
                //new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                // new claim for role
                //new Claim(JwtRegisteredClaimNames.Jti, user.Role),
                // new claim for id
                //new Claim(JwtRegisteredClaimNames.Jti, user.UserId.ToString()),
            //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            // new claim for UserId
            //new Claim("UserId", user.UserId.ToString()),
            // eller så här:
            //new Claim(JwtRegisteredClaimNames.Jti, UserId.NewUserId.ToString()),
            //new Claim(JwtRegisteredClaimNames.Jti, UserId.NewUserId().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
