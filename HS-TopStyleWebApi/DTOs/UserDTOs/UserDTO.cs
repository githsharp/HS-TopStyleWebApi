using HS_TopStyleWebApi.Repos.Entities;
using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.DTOs.UserDTOs
{
    public class UserDTO
    {
        public string FullName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
    }



    //public class UserDTO
    //{
    //    [Required]
    //    public User User { get; set; } = null!;

    //    public string Token { get; set; } = null!;
    //}
}
