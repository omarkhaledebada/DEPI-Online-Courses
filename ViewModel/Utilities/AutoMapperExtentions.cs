using AutoMapper;
using Online_Courses_2024.Models;


namespace Online_Courses_2024.ViewModel.Utilities
{
    public static class AutoMapperExtension
    {
        public static void ConfigAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AssembleType));
        }

        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {

                CreateMap<Course, CourseModelView>();
                CreateMap<CourseModelView, Course>();
                CreateMap<InstructorModelView, Instructor>();
                CreateMap< Instructor, InstructorModelView>();
          
            }
        }
    }
    public class AssembleType
    {
    }
}
