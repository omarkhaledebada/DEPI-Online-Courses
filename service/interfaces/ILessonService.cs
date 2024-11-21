using Online_Courses_2024.Models;

namespace Online_Courses_2024.service.interfaces
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAllLessonsAsync();
        Task<Lesson> GetLessonByIdAsync(int lessonId);
        Task<IEnumerable<Lesson>> GetAllLessonsBycourseId(int crsId);
        Task<Lesson> CreateLessonAsync(Lesson lesson);
        Task<Lesson> UpdateLessonAsync(Lesson lesson);
        Task<bool> DeleteLessonAsync(int lessonId);
    }
}
