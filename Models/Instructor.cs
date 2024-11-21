namespace Online_Courses_2024.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
