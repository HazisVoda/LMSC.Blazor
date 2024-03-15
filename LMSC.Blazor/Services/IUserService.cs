using LMSC.Models;

namespace LMSC.Blazor.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User updatedUser);
    }
}
