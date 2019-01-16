using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string passsword);
        Task<User> Login(string username, string passsword);
        Task<bool> UserExists(string username);
    }
}