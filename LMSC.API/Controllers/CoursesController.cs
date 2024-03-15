using LMSC.API.Models;
using LMSC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMSC.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        public CoursesController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Course>>> SearchCourse(string courseName)
        {
            try
            {
                var result = await courseRepository.SearchCourse(courseName);

                if(result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            try
            {
                return (await courseRepository.GetCourses()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            try
            {
                var result = await courseRepository.GetCourse(id);

                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            try
            {
                if(course == null)
                {
                    return BadRequest();
                }

                var createdCourse = await courseRepository.AddCourse(course);

                return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.CourseID }, createdCourse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Course>> UpdateCourse(int id, Course course)
        {
            try
            {
                if (id != course.CourseID)
                {
                    return BadRequest("Course ID mismatch");
                }

                var courseToUpdate = await courseRepository.GetCourse(id);

                if(courseToUpdate == null)
                {
                    return NotFound($"Course with ID = {id} not found");
                }

                return await courseRepository.UpdateCourse(course);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            try
            {
                var courseToDelete = await courseRepository.GetCourse(id);

                if (courseToDelete == null)
                {
                    return NotFound($"Course with ID = {id} not found");
                }

                return await courseRepository.DeleteCourse(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


    }
}
