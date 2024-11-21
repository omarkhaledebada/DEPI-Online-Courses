using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Courses_2024.Models;
using Online_Courses_2024.ViewModel;

namespace Online_Courses_2024.service.interfaces
{
    public interface IcourseService
    {
        Task<IEnumerable<CourseModelView>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        bool CreateCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
        public IEnumerable<SelectListItem> GetInstructorsAsync();
    }
}
