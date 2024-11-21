using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Courses_2024.service.interfaces;
using Online_Courses_2024.ViewModel;

namespace Online_Courses_2024.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UserController
        
        public async Task<ActionResult> Index()
        {
            List<IdentityUser> users = await _userService.GetAllUsers();
            List<UserViewModel> userView = new List<UserViewModel>();

            for (int i = 0; i < users.Count; i++)
            {
                // Create a new instance of UserViewModel for each user
                UserViewModel viewModel = new UserViewModel
                {
                    Email = users[i].Email,
                    UserName = users[i].UserName
                };

                // Add the new viewModel to the list
                userView.Add(viewModel);
            }

            return View(userView);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
