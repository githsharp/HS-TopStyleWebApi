using HS_TopStyleWebApi.Repos.Entities;

namespace HS_TopStyleWebApi.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
        public string GenerateToken2(User user);
    }
}
