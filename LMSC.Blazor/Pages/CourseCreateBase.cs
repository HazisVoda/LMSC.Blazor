using LMSC.Blazor.Services;
using LMSC.Models;
using Microsoft.AspNetCore.Components;

namespace LMSC.Blazor.Pages
{
    public class CourseCreateBase : ComponentBase
    {
        [Inject]
        public ICourseService CourseService { get; set; }
        public Course Course { get; set; } = new Course();
        public IEnumerable<Course> Courses { get; set; }

        [Parameter]
        public string Id { get; set; }
        public string Description { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Course = await CourseService.GetCourse(int.Parse(Id));
        }

    }
}
