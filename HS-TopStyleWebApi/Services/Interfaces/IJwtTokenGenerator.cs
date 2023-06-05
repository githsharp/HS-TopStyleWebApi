using HS_TopStyleWebApi.Repos.Entities;

namespace HS_TopStyleWebApi.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
