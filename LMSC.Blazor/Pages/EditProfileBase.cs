using AutoMapper;
using LMSC.Blazor.Models;
using LMSC.Blazor.Services;
using LMSC.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;

namespace LMSC.Blazor.Pages
{
    public class EditProfileBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        public User User { get; set; } = new User();
        public EditUserModel EditUserModel { get; set; } = new EditUserModel();
        public List<Role> Roles { get; set; } = new List<Role>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            User = await UserService.GetUser(int.Parse(Id));

            Mapper.Map(User, EditUserModel);
        }

        protected async void HandleValidSubmit()
        {
            Mapper.Map(EditUserModel, User);
            var result = await UserService.UpdateUser(User);
            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
