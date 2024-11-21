using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Courses_2024.Data;
using Online_Courses_2024.Models;
using Online_Courses_2024.service.interfaces;

namespace Online_Courses_2024.service.implementaion
{
    public class AssignmentService : IAssignmentService
    {
        private readonly AppDbContext _context;
       
        public AssignmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAllAssignmentAsync()
        {
            return await _context.Assignments
                .Include(l=>l.Lesson)
                .ToListAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int assignmentId)
        {
            return await _context.Assignments.FindAsync(assignmentId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentByLessonId(int lessonnId)
        {
            return await _context.Assignments.Include(l=> l.Lesson)
                                 .Where(a => a.LessonId == lessonnId)
                                 .ToListAsync();
        }
    
        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<bool> UpdateAssignmentAsync(Assignment assignment)
        {
            var existingAssignment = await _context.Assignments.FindAsync(assignment.AssignmentId);
            if (existingAssignment == null) return false;

            existingAssignment.AssignmentTitle = assignment.AssignmentTitle;
            existingAssignment.Description = assignment.Description;    
            // Update other necessary fields
            _context.Assignments.Update(existingAssignment);
           if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAssignmentAsync(int assignmentId)
        {
            var assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment == null) return false;

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
