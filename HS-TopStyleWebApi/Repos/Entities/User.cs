using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class User: IdentityUser
    {

        // här kan vi lägga på extra properties
        // och lagras tillsammans med andra properties i IdentityUser
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string? FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? Gender { get; set; }

        //varje användare kan ha flera ordrar
        public virtual ICollection <Order>? Orders { get; set; }

       //public User(int userId, string fullName, string email, string password)
       // {
       //     UserId = userId;
       //     FullName = fullName;
       //     Email = email;
       //     Password = password;
       //     Gender = Gender;
       // }

       // public User()
       // {
       // }
    }
}
