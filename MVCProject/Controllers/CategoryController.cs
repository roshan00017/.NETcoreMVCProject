using Microsoft.AspNetCore.Mvc;
using MVCProject.Models.Domain;
using MVCProject.Models.DTO;
using MVCProject.Services.Implementation;
using MVCProject.Services.Interface;
using System;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommonService _commonService;

        public CategoryController(ICategoryService categoryService, ICommonService commonService)
        {
            _categoryService = categoryService;
            _commonService = commonService;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index(int pageNumber = 1, int pageSize = 10, string sortBy = "", string searchQuery = "")
        {
            try
            {
                var taskList = await _categoryService.GetAllCategorysAsync(pageNumber, pageSize, sortBy, searchQuery);

                if (taskList == null)
                {
                    return View("Error");
                }

                ViewBag.PageNumber = pageNumber;
                ViewBag.PageSize = pageSize;
                ViewBag.SortBy = sortBy;
                ViewBag.SearchQuery = searchQuery;
            

                // Set ViewBag.PageCount based on the total number of tasks and pageSize
                var list = await _categoryService.GetAllCategorysAsync(); // Assuming you have a method to get total task count
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

        // GET: CategoryController/Details/5
        public async Task<ActionResult> CategoryDetails(int id)
        {
            var categoryDetails = await _categoryService.GetCategoryByIdAsync(id);
            if (categoryDetails == null)
            {
                return View("Error");
            }
            return View(categoryDetails);
        }

        // GET: CategoryController/Create
        public async Task<ActionResult> CreateCategory()
        {
            ViewBag.Users = await _commonService.UserListAsync();
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCategory(CategoryDto category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isCategoryCreated = await _categoryService.CreateCategoryAsync(category);

                    if (isCategoryCreated)
                    {
                        
                     
                        return RedirectToAction("Index", "Category");
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

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> EditCategory(int id)
        {
            var categoryEdit = await _categoryService.GetCategoryByIdAsync(id);
            if (categoryEdit != null)
            {
                ViewBag.Users = await _commonService.UserListAsync();
                ViewBag.Id = categoryEdit.Id;
                return View(categoryEdit);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCategory(CategoryDto category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryUpdate = await _categoryService.UpdateCategoryAsync(category);
                    if (categoryUpdate)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                }
                ViewBag.Id = category.Id;
                return View(category);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryDel = await _categoryService.GetCategoryByIdAsync(id);
            return View(categoryDel);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
