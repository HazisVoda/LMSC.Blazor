using LMSC.Blazor.Services;
using LMSC.Models;
using Microsoft.AspNetCore.Components;

namespace LMSC.Blazor.Pages
{
    public class CourseListBase : ComponentBase
    {
        [Inject]
        public ICourseService CourseService { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Courses = (await CourseService.GetCourses()).ToList();
        }

    }
}
