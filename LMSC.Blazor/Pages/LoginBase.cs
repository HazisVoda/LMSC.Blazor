using LMSC.Blazor.Services;
using LMSC.Models;
using Microsoft.AspNetCore.Components;

namespace LMSC.Blazor.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        public User User { get; set; } = new User();
        public IEnumerable<Course> Courses { get; set; }

        [Parameter]
        public string Id { get; set; }
        public string Description { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            User = await UserService.GetUser(int.Parse(Id));
        }
    }
}
