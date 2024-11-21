using Online_Courses_2024.Models;


namespace Online_Courses_2024.ViewModel
{
    public class CourseModelView
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string DurationAttribute { get; set; }

        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
