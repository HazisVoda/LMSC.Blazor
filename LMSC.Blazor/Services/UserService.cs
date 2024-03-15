using LMSC.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace LMSC.Blazor.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<User> GetUser(int id)
        {
            return await httpClient.GetFromJsonAsync<User>($"api/users/{id}");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<User[]>("api/users");
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            return await httpClient.PutAsJsonAsync<User>("api/users", updatedUser);
        }
    }
}
