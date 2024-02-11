using Microsoft.AspNetCore.Mvc;
using MVCProject.Models.Domain;
using MVCProject.Models.DTO;
using MVCProject.Services.Implementation;
using MVCProject.Services.Interface;
using System;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public async Task<ActionResult> Index(int pageNumber = 1, int pageSize = 10, string sortBy = "", string searchQuery = "")
        {
            try
            {
                var taskList = await _userService.GetAllUsersAsync(pageNumber, pageSize, sortBy, searchQuery);

                if (taskList == null)
                {
                    return View("Error");
                }

                ViewBag.PageNumber = pageNumber;
                ViewBag.PageSize = pageSize;
                ViewBag.SortBy = sortBy;
                ViewBag.SearchQuery = searchQuery;
                ViewBag.PageTitle = "Task";

                // Set ViewBag.PageCount based on the total number of tasks and pageSize
                var list = await _userService.GetAllUsersAsync(); // Assuming you have a method to get total task count
                var totalCount = list.Count();
                ViewBag.PageCount = (int)Math.Ceiling((double)totalCount / pageSize);

                return View(taskList);
            }
            catch (Exception ex)
            {
                // Log the exception
                return View("Error");
            }
        }


        // GET: UserController/Details/5
        public async Task<ActionResult> UserDetails(int id)
        {
            var userDetails = await _userService.GetUserByIdAsync(id);
            if (userDetails == null)
            {
                return View("Error");
            }
            return View(userDetails);
        }

        // GET: UserController/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUserCreated = await _userService.CreateUserAsync(user);

                    if (isUserCreated)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> EditUser(int id)
        {
            var userEdit = await _userService.GetUserByIdAsync(id);
            if (userEdit != null)
            {
                ViewBag.UserId = userEdit.UserId;
                return View(userEdit);
              
            }
            else
            {
                return View("Error");
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userUpdate = await _userService.UpdateUserAsync(user);
                    if (userUpdate)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                ViewBag.UserId = user.UserId;
                return View(user);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userDel = await _userService.GetUserByIdAsync(id);
            return View(userDel);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               await _userService.DeleteUserAsync(id);
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
