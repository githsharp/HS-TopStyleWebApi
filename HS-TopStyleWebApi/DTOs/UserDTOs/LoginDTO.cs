using System.ComponentModel.DataAnnotations;
using HS_TopStyleWebApi.Repos.Entities;

namespace HS_TopStyleWebApi.DTOs.UserDTOs
{
    public class LoginDTO
    {
        [Required]
        public string? FullName { get; set; } = null!;

        [Required]
        public string? Password { get; set; } = null!;
    }
}
