using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.DTOs.UserDTOs
{
    public class RegisterDTO
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
