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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //private readonly UserManager<User> _usermanager;
        //private readonly SignInManager<User> _signinmanager;

        // Vi injectar de delar av Identity som ska användas.
        // // här tex usermanager och signinmanager
        //public AuthenticationController(UserManager<User> usermanager, SignInManager<User> signinmanager)
        //{
        //    _usermanager = usermanager;
        //    _signinmanager = signinmanager;
        //}

        private readonly ProductContext _db;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;


        public AuthenticationController(ProductContext db, IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        // Register a user
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task< IActionResult >RegisterUser(RegisterDTO user)
        {
            var userInDb = _db.Users.FirstOrDefault(u => u.Email == user.Email);
            var createdUser = await _userRepository.RegisterUser(user);
            var token = _jwtTokenGenerator.GenerateToken2(createdUser);
            return Ok(token);
        }

        // Login a user
        [AllowAnonymous]
        [HttpPost("login")]

        public async Task <IActionResult>LoginUser(LoginDTO user)
        {
            var userInDb = _db.Users.FirstOrDefault(u => u.FullName == user.FullName && u.Password == user.Password);
            var createdUser = await _userRepository.LoginUser(user);
            var token = _jwtTokenGenerator.GenerateToken2(createdUser);
            return Ok(token);
        }

        //public async Task<IActionResult> Login(LoginDTO loginDTO)
        //{
        //    var user = await _db.Users.FirstOrDefaultAsync(u => u.FullName == loginDTO.FullName && u.Password == loginDTO.Password);
        //    return user is null ? NotFound() : Ok(loginDTO);
        //    //var token = _jwtTokenGenerator.GenerateToken(user);
        //    UserDTO userDTO = new UserDTO
        //    {
        //        FullName = user.FullName,
        //        Password = user.Password
        //    };

        //    return user is not null ? Ok(loginDTO) : NotFound();

        //}

    }
}
