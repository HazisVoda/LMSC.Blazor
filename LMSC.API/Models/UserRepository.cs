using LMSC.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSC.API.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<User> GetUser(int userId)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.UserID == userId);
        }
        public async Task<User> UpdateUser(User user)
        {
            var result = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);

            if (result == null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Email = user.Email;
                result.RoleID = user.RoleID;
                result.DateOfBirth = user.DateOfBirth;
                result.Gender = user.Gender;
                result.PhotoPath = user.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async Task<User> AddUser(User user)
        {
            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<User> DeleteUser(int userId)
        {
            var result = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserID == userId);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }

            return null;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUserByName(string firstName)
        {
            IQueryable<User> query = appDbContext.Users;
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(u => u.FirstName.Contains(firstName));
            }

            return await query.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }


    }
}
