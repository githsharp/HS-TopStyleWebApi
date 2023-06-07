using Microsoft.AspNetCore.Identity;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class ApplicationUser: IdentityUser
    {

    // här kan vi lägga på extra properties
    // och lagras tillsammans med andra properties i IdentityUser

    public string? Gender { get; set; }
    }
}
