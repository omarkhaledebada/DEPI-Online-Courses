using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Online_Courses_2024.Models;
using Online_Courses_2024.service.implementaion;
using Online_Courses_2024.service.interfaces;
using System.Security.Claims;

namespace Online_Courses_2024.Controllers
{
    //[Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IcourseService _courseservice;
        private readonly IAssignmentService _assignmentService;
        private readonly IProgressService _progressService;
        public CourseController(ILessonService lessonService, IcourseService courseservice, IAssignmentService assignmentService, IProgressService progressService)
        {
            _lessonService = lessonService;
            _courseservice = courseservice;
            _assignmentService = assignmentService;
            _progressService = progressService;
        }
        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var coursesViewModel = await _courseservice.GetCoursesAsync();
            return View("CourseCards", coursesViewModel);
        }

        //for Admin Dashboard
        [HttpGet]
        public async Task<IActionResult> getCoursesForAdmin()
        {
            var coursesViewModel = await _courseservice.GetCoursesAsync();
            return View(coursesViewModel);
        }

        // GET: api/Course/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Instructors =  _courseservice.GetInstructorsAsync();
            return View();
        }

        // POST: api/Course/Create
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if ( _courseservice.CreateCourseAsync(course))
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Instructors =  _courseservice.GetInstructorsAsync();
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Instructors = _courseservice.GetInstructorsAsync();
            return View(await _courseservice.GetCourseByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            if (await _courseservice.UpdateCourseAsync(course))
            {
                return RedirectToAction(nameof(getCoursesForAdmin));
            }

            // Handle the error (return the view with the model)
            ViewBag.Instructors =  _courseservice.GetInstructorsAsync();
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _courseservice.GetCourseByIdAsync(id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _courseservice.DeleteCourseAsync(id))
            {
                return RedirectToAction(nameof(getCoursesForAdmin));
            }

            return NotFound();
        }



        // GET: api/Course/GetById/{id}
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var lessons = await _lessonService.GetAllLessonsBycourseId(id);
            var assignments = await _assignmentService.GetAllAssignmentAsync();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var progress = await _progressService.GetProgressForUserCourse(userId,id);
            ViewBag.Assignment = assignments;
            //ViewBag.Assignment = JsonConvert.SerializeObject(assignments);
            ViewBag.Progress = progress;
            ViewBag.Courseid = id;
            return View(lessons);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProgress(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _progressService.UpdateProgress(userId ,id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> getProgress(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           var progress= await _progressService.GetProgressForUserCourse(userId, id);
            return Json(progress);
        }
    }
}
