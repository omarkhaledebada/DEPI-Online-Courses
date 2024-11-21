using Microsoft.AspNetCore.Identity;

namespace Online_Courses_2024.service.interfaces
{
    public interface IUserService
    {
        public Task<List<IdentityUser>> GetAllUsers();

    }
}
