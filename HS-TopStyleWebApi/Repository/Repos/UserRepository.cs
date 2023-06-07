using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
//using HS_TopStyleWebApi.Extensions;
using HS_TopStyleWebApi.Repository.Interfaces;
using HS_TopStyleWebApi.Repository.Repos;
using HS_TopStyleWebApi.DTOs.UserDTOs;
using HS_TopStyleWebApi.Repos.Entities;
using System.Linq;

namespace HS_TopStyleWebApi.Repository.Repos
{
    public class UserRepository : IUserRepository
    {
        // sätts upp via Dependency Injection för att kunna läsa från databasen
        private readonly ProductContext _db;
        public UserRepository(ProductContext db)
        {
            _db = db;
        }

        // POST - Register user

        public async Task<User> RegisterUser(RegisterDTO user)
        {
            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Gender = user.Gender,

            }; 
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            var createdUser = await _db.Users.SingleOrDefaultAsync(u => u.UserId == newUser.UserId);
            return createdUser;
        }   

        //POST - Login User
        public async Task<User?> LoginUser(LoginDTO loginDTO)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.FullName == loginDTO.FullName && u.Password == loginDTO.Password);
            return user;
        }
    }
}
