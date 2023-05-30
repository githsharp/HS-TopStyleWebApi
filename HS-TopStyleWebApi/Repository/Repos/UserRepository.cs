using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using HS_TopStyleWebApi.Extensions;
using HS_TopStyleWebApi.Repository.Interfaces;
using HS_TopStyleWebApi.Repository.Repos;
using HS_TopStyleWebApi.DTOs.UserDTOs;
using HS_TopStyleWebApi.Repos.Entities;
using System.Linq;

namespace HS_TopStyleWebApi.Repository.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ProductContext _context;

        public UserRepository(IConfiguration configuration, ProductContext context)
        {
            _configuration = configuration;
            _context = context;
            //alt:
            //_db = db;
        }

        // POST - Register User
        public async Task<int> RegisterUser(RegisterDTO user)
        {
            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,

            }; await _context.SaveChangesAsync();
            return newUser.UserId;
        }

        public async Task<User?> LoginUser(LoginDTO loginDTO)
        {
            //using var db = new ProductContext();
            // hur avsluta ProductContext?

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            //var user = await db.Users.FirstOrDefaultAsync(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            return user;
        }
    }
}
