using System.ComponentModel.DataAnnotations;

namespace LMSC.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [Required]
        [MinLength(5)]
        public string CourseName { get; set; }
        public string CourseDetails { get; set; }
        public string PhotoPath { get; set; }
    }
}
