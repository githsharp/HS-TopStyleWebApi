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
        // prova denna?
        Task<int> RegisterUser(RegisterDTO user);
        //alt:
        //Task<int> RegisterUser(RegisterDTO user);

        // POST - Login User
        // prova denna?
       // Task<UserDTO?> LoginUser(UserDTO user);
        Task<User?> LoginUser(LoginDTO loginDTO);
        // alt:
        //Task<User?> LoginUser(LoginDTO loginDTO);

    }
}
