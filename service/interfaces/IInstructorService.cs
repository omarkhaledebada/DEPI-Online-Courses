using Online_Courses_2024.ViewModel;

namespace Online_Courses_2024.service.interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorModelView>> GetInstructors();
        public Task<InstructorModelView> GetInstructorById(int id);
        bool Add(InstructorModelView instructorModelView);
       
        Task Update(InstructorModelView instructorModelView);
        Task Delete(int id);
        

    }
}
