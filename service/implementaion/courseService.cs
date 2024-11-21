using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Courses_2024.Data;
using Online_Courses_2024.Models;
using Online_Courses_2024.service.interfaces;
using Online_Courses_2024.ViewModel;

namespace Online_Courses_2024.service.implementaion
{
    public class courseService : IcourseService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public courseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseModelView>> GetCoursesAsync()
        {
        
            var Courses=await _context.Courses
                .Include(c=>c.Instructor).ToListAsync();
            return _mapper.Map<List<CourseModelView>>(Courses);
        }

        public  IEnumerable<SelectListItem> GetInstructorsAsync()
        {
            return _context.Instructors.AsNoTracking().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Name}"
            }).ToList();
        }
    
        public  bool CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);

            if(_context.SaveChanges() > 0)
            {

                return true;
            }
            return false;
        }



        public async Task<bool> UpdateCourseAsync(Course course)
        {
            if (course == null) return false;

            _context.Courses.Update(course);
            return await _context.SaveChangesAsync() > 0; 
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            return await _context.SaveChangesAsync() > 0; 
        }



        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.Include(c => c.Instructor)
                                         .FirstOrDefaultAsync(c => c.CourseId == id);
        }

    }
}
