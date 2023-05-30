using HS_TopStyleWebApi.Repos.Entities;

namespace HS_TopStyleWebApi.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
        //string GenerateToken(UserDTO? user);
        //object GenerateToken(Task<UserDTO?> user);
    }
}
