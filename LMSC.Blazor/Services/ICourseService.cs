using LMSC.Models;

namespace LMSC.Blazor.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
    }
}
