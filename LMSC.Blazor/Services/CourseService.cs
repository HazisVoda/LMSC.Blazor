using LMSC.Models;

namespace LMSC.Blazor.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient httpClient;
        public CourseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Course> GetCourse(int id)
        {
            return await httpClient.GetFromJsonAsync<Course>($"api/courses/{id}");
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await httpClient.GetFromJsonAsync<Course[]>("api/courses");
        }
    }
}
