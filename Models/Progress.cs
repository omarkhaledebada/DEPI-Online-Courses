using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Courses_2024.Models
{
    public class Progress
    {
        [Key, Column(Order = 0)]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [ForeignKey("User")]
        [Key, Column(Order = 1)]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}