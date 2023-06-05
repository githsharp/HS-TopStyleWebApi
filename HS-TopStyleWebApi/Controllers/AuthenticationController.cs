using HS_TopStyleWebApi.DTOs;
using HS_TopStyleWebApi.DTOs.UserDTOs;
using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Repository.Repos;
using HS_TopStyleWebApi.Services.Authentication;
using HS_TopStyleWebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HS_TopStyleWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        //public AuthenticationController(IUserRepository userRepository,
        //                                IJwtTokenGenerator jwtTokenGenerator)
        //{
        //    _userRepository = userRepository;
        //    _jwtTokenGenerator = jwtTokenGenerator;
        //}

        private readonly ProductContext _db;

        public AuthenticationController(ProductContext db)
        {
            _db = db;
            //_context = context;
        }

        // [AllowAnonymous]
        //register a user
        [HttpPost("register")]
        //public IActionResult RegisterUser(RegisterDTO user, User newUser)
        public IActionResult RegisterUser(RegisterDTO user)
        {
            var userInDb = _db.Users.FirstOrDefault(u => u.Email == user.Email);
            return Ok("A new user is successfully created {newUser}");
        }

        //{
        //    _db.Users.Add(newUser);
        //    _db.SaveChanges();
        //    return Ok("A user was successfully created");
        //}

        //var userInDb = _db.Users.FirstOrDefault(u => u.Email == user.Email);
        //if (userInDb != null)
        //{
        //   return BadRequest();
        //}
        //var newUser = new User;
        //userDTO = new UserDTO;
        //    return newUser.UserId;
        //{
        //    FullName = user.FullName,
        //    Email = user.Email,
        //    Password = user.Password,
        //};
        //_db.Users.Add(newUser);
        //_db.SaveChanges();
        //return Ok(newUser);

        ////var userInDb = _db.Users.FirstOrDefault(u => u.Email == user.Email);
        ////if (userInDb != null)
        ////{
        ////    return BadRequest();
        ////}
        // denna anses nog vara en dublett för att den finns i User.cs
        //var newUser = new User
        //{
        //    FullName = user.FullName,
        //    Email = user.Email,
        //    Password = user.Password,
        //};
        //_db.Users.Add(User);
        //_db.SaveChanges();
        //return Ok(User);

        //[AllowAnonymous]
        //login a user
        [HttpPost("login")]
        //public IActionResult LoginUser(User user)
        public async Task <IActionResult> Login(LoginDTO loginDTO)
        {
            //var user = await _db.LoginUser(loginDTO);
            var user = await _db.Users.FirstOrDefaultAsync(u => u.FullName == loginDTO.FullName && u.Password == loginDTO.Password);
            var token = _jwtTokenGenerator.GenerateToken(user);
            UserDTO userDTO = new UserDTO
            {
                User = user,
                Token = token
            };
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //return Ok(UserDTO);
            return user is not null ? Ok(loginDTO) : NotFound();
        }

    }
}
