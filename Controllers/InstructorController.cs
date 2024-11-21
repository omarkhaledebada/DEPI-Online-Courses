using Microsoft.AspNetCore.Mvc;
using Online_Courses_2024.service.interfaces;
using Online_Courses_2024.ViewModel;

namespace Online_Courses_2024.Controllers
{
    
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<IActionResult> Index()
        {
            var Instuctors = await _instructorService.GetInstructors();
            return View(Instuctors);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InstructorModelView instructorModelView)
        {

            if (_instructorService.Add(instructorModelView))
            {

                return RedirectToAction(nameof(Index));
            }

            return View(instructorModelView);
        }

        public async Task<IActionResult> Edit(int id)
        {
            

            var instructor = await _instructorService.GetInstructorById(id);
          
            return View(instructor);
        }
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id, InstructorModelView instructorModelView)
        {
            
            
            //if (ModelState.IsValid)
            //{
                await _instructorService.Update(instructorModelView);
                return RedirectToAction(nameof(Index));
            }
        //  return View(instructor);
        //}

        public async Task<IActionResult> Delete(int? id)
        {
         

            var instructor = await _instructorService.GetInstructorById(id.Value);
       
            return View(instructor);
        }

        [HttpPost]
    
        public async Task<IActionResult> Delete(int id)
        {
            await _instructorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //////////////////////////////////////////////
        //////////////////////////////////
        ////////////////////////////
        ///

        public async Task<IActionResult> About(int id)
        {
            
            return View("About", await _instructorService.GetInstructors());
        }

    }
}
