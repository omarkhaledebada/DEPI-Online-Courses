using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Courses_2024.Models
{
	public class Enrollment
	{
		public int EnrollmentId { get; set; }
		public DateTime EnrollmentDate { get; set; }
		[ForeignKey("User")]
        public string StudentId { get; set; }
        public User Student { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
