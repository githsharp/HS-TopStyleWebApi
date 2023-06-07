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
using Microsoft.AspNetCore.Identity;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinmanager;

        // Vi injectar de delar av Identity som ska användas.
        // // här tex usermanager och signinmanager
        public AuthenticationController(UserManager<User> usermanager, SignInManager<User> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }

        // Register a user
        //[HttpPost("{user}")]
        //[Route("api/[action]")]
        //[Route("api/register")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO user)
        {
            //if (user is null) return BadRequest("Felaktig användare");

            // skapar en ny användare
            var newUser = new User()
            {
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender,
            };

            // sparar ner användaren i databasen
            var result = await _usermanager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                return Ok("Användaren skapad");
            }
            else
            {
                return BadRequest("Någonting gick fel. Vänligen försök igen.");
            }
        }

        // Login a user

        [HttpPost("login")]

        public async Task<IActionResult> Login(UserDTO user)
        {
            //testar vår inloggning och får tillbaka ett resultat
            var result = await _signinmanager.PasswordSignInAsync(user.FullName, user.Password, false, false);

            if (result.Succeeded)
            {
                //normala steg här är att först hämta claims/roles och sedan skapa en JWT
                // token som skickas tillbaka till klienten

                return Ok("Inloggningen gick bra. Här skickas en token med tillbaka");
            }

            else
            {
                return Unauthorized("Felaktig inloggning. Vänligen försök igen");
            }

        }




        /*

        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        //public AuthenticationController(IUserRepository userRepository,
        //                                IJwtTokenGenerator jwtTokenGenerator)
        //{
        //    _userRepository = userRepository;
        //    _jwtTokenGenerator = jwtTokenGenerator;
        //}

        private readonly ProductContext? _db;

        public AuthenticationController(ProductContext db)
        {
            _db = db;
        }

        // [AllowAnonymous]
        //register a user
        [HttpPost("register")]
        public async Task <IActionResult> RegisterUser(RegisterDTO user)
        {
            //var userInDb = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            var userInDb = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            _db.SaveChanges();
            return Ok(user);
            //_db.Users.Add(_db.Users.FirstOrDefault(u => u.Email == user.Email));

            //var user = await _db.RegisterUser(user);
            //var newUser = new User

            //var NewUser = new user { FullName = user.FullName, Email = user.Email, Password = user.Password, };
            //{
            //    FullName = user.FullName,
            //    Email = user.Email,
            //    Password = user.Password,
            //};
            //await _db.SaveChangesAsync();
            //return Ok("A new user is successfully created {newUser}");

            //var userInDb = await _db.Users.FirstOrDefault(u => u.Email == user.Email);

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
        */

    }
}
