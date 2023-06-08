using HS_TopStyleWebApi.DTOs.UserDTOs; 
using HS_TopStyleWebApi.Repos.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repository.Interfaces
{
    public interface IUserRepository
    {

        // POST - Register User
        Task<User> RegisterUser(RegisterDTO user);

        // POST - Login User
        Task<User?> LoginUser(LoginDTO loginDTO);
    }
}
