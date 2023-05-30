using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        //varje användare kan ha flera ordrar
        public virtual ICollection <Order>? Orders { get; set; }
        public User()
        {
        }

    }
}
