using Microsoft.AspNetCore.Mvc;
using Online_Courses_2024.service.interfaces;

namespace Online_Courses_2024.Controllers
{

    //[Route("api/[controller]")]
    public class EnrollController : Controller
    {
        private readonly ILessonService _lessonService;
        public EnrollController(ILessonService lessonService)
        {
            _lessonService = lessonService; 
        }

        [HttpGet]
        public IActionResult Submit(int id)
        {  
            ViewBag.Id = id;
           return View();
        }

        //[HttpPost]
        //public IActionResult Submit(int Id, string name = "")
        //{

        //    var lessons = _lessonService.GetAllLessonsBycourseId(Id);
        //    return RedirectToAction("GetById", "course", lessons);
        //}
    }
}
