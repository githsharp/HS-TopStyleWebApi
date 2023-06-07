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

        //private readonly IConfiguration _configuration;
        //private readonly ProductContext _context;

        //public UserRepository(IConfiguration configuration, ProductContext db)
        //{
        //    _configuration = configuration;
        //    _db = db;
        //    //_db = db;
        //}

        // POST - Register user - using linq and lambda and async task with RegisterDTO

        public async Task<int> RegisterUser(RegisterDTO user)
        {
            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,

            }; await _db.SaveChangesAsync();
            return newUser.UserId;
        }   


        //public async Task<int> RegisterUser(RegisterDTO user)
        //{
        //    var newUser = new User
        //    {
        //        FullName = user.FullName,
        //        Email = user.Email,
        //        Password = user.Password,

        //    }; await _db.SaveChangesAsync();
        //    return newUser.UserId;
        //}

        //POST - Login User
        public async Task<User?> LoginUser(LoginDTO loginDTO)
        {
            //using var db = new ProductContext();
            // hur avsluta ProductContext?
            
            // här ska db vara istf _context
            var user = await _db.Users.FirstOrDefaultAsync(u => u.FullName == loginDTO.FullName && u.Password == loginDTO.Password);
            //var user = await db.Users.FirstOrDefaultAsync(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            return user;
        }
    }
}
