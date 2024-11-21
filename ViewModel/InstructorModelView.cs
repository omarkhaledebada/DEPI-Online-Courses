using Online_Courses_2024.Models;

namespace Online_Courses_2024.ViewModel
{
    public class InstructorModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
