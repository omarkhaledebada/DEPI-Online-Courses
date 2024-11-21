namespace Online_Courses_2024.Models
{
	public class Lesson
	{
		public int LessonId { get; set; }
		public string LessonTitle { get; set; }
		public string Content { get; set; }
		public int CourseId { get; set; }
		public Course Course { get; set; }

        public List<Progress> Progress { get; set; }
    }
}
