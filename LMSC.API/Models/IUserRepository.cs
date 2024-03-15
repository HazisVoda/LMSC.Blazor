using LMSC.Models;

namespace LMSC.API.Models
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetUserByName(string firstName);
        Task<User> GetUserByEmail(string email);
        Task<User> UpdateUser(User user);
        Task<User> AddUser(User user);
        Task<User> DeleteUser(int userId);
    }
}
