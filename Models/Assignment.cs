namespace Online_Courses_2024.Models
{
	public class Assignment
	{
		public int AssignmentId { get; set; }
		public string AssignmentTitle { get; set; }
		public string Description { get; set; }
		public int LessonId { get; set; }
		public Lesson Lesson { get; set; }


	}
}
