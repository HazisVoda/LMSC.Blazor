using LMSC.Blazor.Services;
using LMSC.Models;
using Microsoft.AspNetCore.Components;

namespace LMSC.Blazor.Pages
{
    public class CourseEditBase : ComponentBase
    {
        [Inject]
        public ICourseService CourseService { get; set; }
        public Course Course { get; set; } = new Course();
        [Parameter]
        public string Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Course = await CourseService.GetCourse(int.Parse(Id));
        }
    }
}
