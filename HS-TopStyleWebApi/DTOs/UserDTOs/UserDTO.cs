using HS_TopStyleWebApi.Repos.Entities;
using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.DTOs.UserDTOs
{
    public class UserDTO
    {
        [Required]
        public User User { get; set; } = null!;

        public string Token { get; set; } = null!;
    }
}
