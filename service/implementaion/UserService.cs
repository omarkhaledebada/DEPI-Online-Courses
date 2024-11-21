using AutoMapper;
using Online_Courses_2024.Models;
using Microsoft.AspNetCore.Identity;
using Online_Courses_2024.Data;
using Online_Courses_2024.service.interfaces;

namespace Online_Courses_2024.service.implementaion
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async  Task<List<IdentityUser>> GetAllUsers()
        {
            return  _userManager.Users.ToList();
        }
    }
}
