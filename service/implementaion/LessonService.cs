using Online_Courses_2024.Models;
using Microsoft.EntityFrameworkCore;
using Online_Courses_2024.Data;
using Online_Courses_2024.service.interfaces;

namespace Online_Courses_2024.service.implementaion
{
    public class LessonService : ILessonService
    {
        private readonly AppDbContext _context;

        public LessonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Lesson>> GetAllLessonsAsync()
        {
        return await _context.Lessons.Include(l => l.Course).ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsBycourseId(int crsId)
        {
            return await _context.Lessons.Include(l => l.Course)
                .Where(a=>a.CourseId== crsId)
                .ToListAsync();
        }
        public async Task<Lesson> GetLessonByIdAsync(int lessonId)
        {
            return await _context.Lessons.Include(l => l.Course).FirstOrDefaultAsync(l => l.LessonId == lessonId);
        }

        public async Task<Lesson> CreateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
     
            return lesson;
        }

        public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
        {
              _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<bool> DeleteLessonAsync(int lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson == null)
            {
                return false;
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
