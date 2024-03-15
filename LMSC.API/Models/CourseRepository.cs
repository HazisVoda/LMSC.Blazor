using LMSC.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LMSC.API.Models
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        
        public async Task<Course> GetCourse(int courseId)
        {
            return await appDbContext.Courses.FirstOrDefaultAsync(c => c.CourseID == courseId);
        }
        public async Task<Course> UpdateCourse(Course course)
        {
            var result = await appDbContext.Courses.FirstOrDefaultAsync(c => c.CourseID == course.CourseID);

            if (result == null)
            {
                result.CourseName = course.CourseName;
                result.CourseDetails = course.CourseDetails;
                result.PhotoPath = course.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async Task<Course> AddCourse(Course course)
        {
            var result = await appDbContext.Courses.AddAsync(course);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Course> DeleteCourse(int courseId)
        {
            var result = await appDbContext.Courses.FirstOrDefaultAsync(c => c.CourseID == courseId);
            if(result != null)
            {
                appDbContext.Courses.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await appDbContext.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> SearchCourse(string courseName)
        {
            IQueryable<Course> query = appDbContext.Courses;
            if(!string.IsNullOrEmpty(courseName))
            {
                query = query.Where(c => c.CourseName.Contains(courseName));
            }

            return await query.ToListAsync();
        }
    }
}
