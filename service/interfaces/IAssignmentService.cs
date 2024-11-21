

using Online_Courses_2024.Models;

namespace Online_Courses_2024.service.interfaces
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAllAssignmentAsync();
        Task<Assignment> GetAssignmentByIdAsync(int assignmentId);
        Task<IEnumerable<Assignment>> GetAssignmentByLessonId(int lessonId);
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<bool> UpdateAssignmentAsync(Assignment assignment);
        Task<bool> DeleteAssignmentAsync(int assignmentId);
    }
}
