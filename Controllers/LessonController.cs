using Microsoft.AspNetCore.Mvc;
using Online_Courses_2024.Models;
using Online_Courses_2024.service.implementaion;
using Online_Courses_2024.service.interfaces;

namespace Online_Courses_2024.Controllers
{
    //[Route("api/[controller]")] /// api/ASsigment
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IcourseService _courseService;
        private readonly IAssignmentService _assignmentService;
        public LessonController(ILessonService lessonService, IcourseService courseService, IAssignmentService assignmentService)
        {
            _lessonService = lessonService;
            _courseService = courseService;
            _assignmentService= assignmentService;
        }

        // GET: api/lesson
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            return View(lessons);
        }

        // GET: api/lesson/{id}
        [HttpGet]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(lesson);
        }

        // GET: api/lesson/create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var courses = await _courseService.GetCoursesAsync();
            ViewBag.courses = courses;
            return View();
        }

        // POST: api/lesson/create
        [HttpPost]
        public async Task<IActionResult> Create(Lesson lesson)
        {
            var courses = await _courseService.GetCoursesAsync();
            if (lesson.CourseId == 0)
            {
                ViewBag.courses = courses;
                ModelState.AddModelError("", "Must select a course.");
                return View(lesson);
            }

            var createdLesson = await _lessonService.CreateLessonAsync(lesson);
            if (createdLesson == null)
            {
                ViewBag.courses = courses;
                return View(lesson);
            }

            var lessons = await _lessonService.GetAllLessonsAsync();
            return View("Index", lessons);
        }

        // GET: api/lesson/update/{id}
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            var courses = await _courseService.GetCoursesAsync();
            ViewBag.courses = courses;
            return View(lesson);
        }

        // POST: api/lesson/update/{id}
        [HttpPost]
        public async Task<IActionResult> Update(Lesson lesson, int id)
        {
            var updatedLesson = await _lessonService.UpdateLessonAsync(lesson);
            if (updatedLesson == null)
            {
                var courses = await _courseService.GetCoursesAsync();
                ViewBag.courses = courses;
                return View(lesson);
            }

            var lessons = await _lessonService.GetAllLessonsAsync();
            return View("Index", lessons);
        }

       
       
        // GET: Lesson/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // Retrieve the lesson by ID
            var lesson = await _lessonService.GetLessonByIdAsync(id);
          
            return View(lesson);
        }

        // POST: Lesson/Delete/{id}

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string x = "zxc")
        {
            await _lessonService.DeleteLessonAsync(id);

            var lessons = await _lessonService.GetAllLessonsAsync();

            return View("Index", lessons);
        }



        //[HttpGet]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var assignments = await _assignmentService.GetAssignmentByLessonId(id);
        //    return View(assignments);
        //}


    }
}
