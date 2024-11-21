using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Courses_2024.Models
{
	public class Course
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string DurationAttribute { get; set; }

        [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
