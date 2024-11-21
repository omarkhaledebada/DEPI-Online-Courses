using Microsoft.AspNetCore.Mvc;
using Online_Courses_2024.Models;
using Online_Courses_2024.service.interfaces;

namespace Online_Courses_2024.Controllers
{
   // [Route("api/[controller]")] //Assignment//index
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;
        private readonly ILessonService _lessonService;
        private readonly IcourseService _courseService;

        public AssignmentController(IAssignmentService assignmentService, ILessonService lessonService, IcourseService courseService)
        {
            _assignmentService = assignmentService;
            _lessonService = lessonService;
            _courseService = courseService;
        }

        // GET: api/Assignment
        [HttpGet]
        public async Task<ActionResult<List<Assignment>>> Index()
        {
            var assignments = await _assignmentService.GetAllAssignmentAsync();
            return View(assignments);
        }

        // GET: api/Assignment/{id}
        [HttpGet]
        public async Task<ActionResult<Assignment>> GetAssignmentById(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        // GET: api/Assignment/Create
        [HttpGet]
        public async Task<ActionResult<Assignment>> Create()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            var courses = await _courseService.GetCoursesAsync();
            ViewBag.Lessons = lessons;
            ViewBag.Course = courses;
            return View();
        }

        // POST: api/Assignment/Create
        [HttpPost]
        public async Task<ActionResult<Assignment>> Create(Assignment assignment)
        {
            var createdAssignment = await _assignmentService.CreateAssignmentAsync(assignment);
            var assignments = await _assignmentService.GetAllAssignmentAsync();
            return View("Index", assignments);
        }

        // PUT: api/Assignment/{id}
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var lesson = await _assignmentService.GetAssignmentByIdAsync(id);
            var courses = await _lessonService.GetAllLessonsAsync();
            ViewBag.Lessons = courses;
            return View(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Assignment assignment, int id)
        {
            var updatedAssignment = await _assignmentService.UpdateAssignmentAsync(assignment);
            if (updatedAssignment == null)
            {
                var lessons = await _lessonService.GetAllLessonsAsync();
                ViewBag.Lessons = lessons;
                return View(assignment);
            }

            var assignments = await _assignmentService.GetAllAssignmentAsync();
            return View("Index", assignments);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
           
            return View(assignment);
        }
        // DELETE: api/Assignment/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id,string x="zxc")
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            var assignments = await _assignmentService.GetAllAssignmentAsync();
            return View("Index", assignments);
        }
    }

}
