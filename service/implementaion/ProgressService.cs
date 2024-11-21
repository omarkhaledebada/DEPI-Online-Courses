using Microsoft.EntityFrameworkCore;
using Online_Courses_2024.Data;
using Online_Courses_2024.Models;
using Online_Courses_2024.service.interfaces;
using System;

namespace Online_Courses_2024.service.implementaion
{
    public class ProgressService:IProgressService
    {
        private readonly AppDbContext _context;
        public ProgressService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetProgressForUserCourse(string userID, int courseID)
        {
            var lessons =  _context.Lessons.Where(c => c.CourseId == courseID).ToList();
            var prousers= _context.progresses
                         .Where(u => u.UserId == userID)

                         .ToList();
            var Counter = 0;
            foreach (var item in lessons)
            {
                foreach( var item2 in prousers)
                {
                    if (item.LessonId == item2.LessonId)
                        Counter++;


                }

            }
            int percentage = (int)((float)Counter / lessons.Count() * 100);
            return percentage;
        }


        public async Task UpdateProgress(string userID, int LessonID)
        {
            // تحقق مما إذا كان هناك سجل موجود بالفعل في Progress للـ UserId و LessonId
            var existingProgress = await _context.progresses
                .FirstOrDefaultAsync(p =>  p.LessonId == LessonID && p.UserId==userID);

            if (existingProgress == null) 
            {
                var progress = new Models.Progress
                {
                    UserId = userID,
                    LessonId = LessonID
                };

                await _context.progresses.AddAsync(progress);
                await _context.SaveChangesAsync();
            }
            else
            {
                // يمكنك هنا تنفيذ أي عملية إذا كان السجل موجودًا بالفعل (مثلاً، تحديث التقدم إذا لزم الأمر)
                Console.WriteLine("Progress already exists for this user and lesson.");
            }
        }
    }
}
