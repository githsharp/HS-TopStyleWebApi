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
            var signingCredentials = new SigningCredentials(
                               new SymmetricSecurityKey
                               (Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
                               SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
                //claims: new[]
                //{
                //    new Claim(ClaimTypes.Name, user.Email),
                //    new Claim(ClaimTypes.Role, user.Role)
                //},)
        }
    }
}
