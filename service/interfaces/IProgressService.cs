namespace Online_Courses_2024.service.interfaces
{
    public interface IProgressService
    {
       public Task<int> GetProgressForUserCourse(string userID, int CourseID);

        public Task UpdateProgress(string userID, int CourseID); 
    }
}
