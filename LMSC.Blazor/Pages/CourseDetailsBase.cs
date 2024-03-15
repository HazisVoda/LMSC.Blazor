using LMSC.Blazor.Services;
using LMSC.Models;
using Microsoft.AspNetCore.Components;

namespace LMSC.Blazor.Pages
{
    public class CourseDetailsBase : ComponentBase
    {
        public Course Course { get; set; } = new Course();

        [Inject]
        public ICourseService CourseService { get; set; }

        [Parameter]
        public string ID { get; set; }

        protected async override Task OnInitializedAsync()
        {
            ID = ID ?? "1";
            Course = await CourseService.GetCourse(int.Parse(ID));
        }
    }
}
