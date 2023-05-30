using HS_TopStyleWebApi.Repos.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //private readonly IAuthenticationRepository _authenticationRepository;
        private readonly ProductContext _db;

        public AuthenticationController(ProductContext db)
        {
            _db = db;
        }

        //register a user
        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        //login a user
        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            var userInDb = _db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (userInDb == null)
            {
                return NotFound();
            }
            return Ok(userInDb);
        }
    }
}
