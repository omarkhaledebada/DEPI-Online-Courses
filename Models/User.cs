using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace Online_Courses_2024.Models
{
    public class User:IdentityUser
    {
    
    public List<Progress> Progress { get; set; }
}
}
