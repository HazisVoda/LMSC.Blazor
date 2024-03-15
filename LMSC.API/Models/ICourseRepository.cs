using LMSC.Models;

namespace LMSC.API.Models
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<IEnumerable<Course>> SearchCourse(string courseName);
        Task<Course> GetCourse(int courseId);
        Task<Course> UpdateCourse(Course course);
        Task<Course> AddCourse(Course course);
        Task<Course> DeleteCourse(int courseId);
    }
}
