using AutoMapper;
using Online_Courses_2024.Models;
using Microsoft.EntityFrameworkCore;
using Online_Courses_2024.Data;
using Online_Courses_2024.service.interfaces;
using Online_Courses_2024.ViewModel;

namespace Online_Courses_2024.service.implementaion
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public InstructorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       public async Task<IEnumerable<InstructorModelView>> GetInstructors()
        {
            var instructors = await _context.Instructors.ToListAsync();
            return _mapper.Map<List<InstructorModelView>>(instructors);

        }
        public async Task<InstructorModelView> GetInstructorById(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            return _mapper.Map<InstructorModelView>(instructor);
        }

       
        public async Task Update(InstructorModelView instructorModelView)
        {
            var instructor = _mapper.Map<Instructor>(instructorModelView);
            _context.Update(instructor);
            await _context.SaveChangesAsync();
        }


        bool IInstructorService.Add(InstructorModelView instructorModelView)
        {
            var instructor = _mapper.Map<Instructor>(instructorModelView);
            _context.Instructors.Add(instructor);

            if (_context.SaveChanges() > 0)
            {

                return true;
            }
            return false;
        }

        public async Task Delete(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
        }

        
        

    }
}
