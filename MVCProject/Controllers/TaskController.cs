using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models.DTO;
using MVCProject.Repository.Implemenentaion;
using MVCProject.Repository.Interfaces;
using MVCProject.Services.Implementation;
using MVCProject.Services.Interface;

namespace MVCProject.Controllers
{
    public class TaskController : Controller
    {

        public readonly ITaskService _taskService;
        public readonly ICommonService _commonService;
        private string? Error;

        public TaskController(ITaskService taskService,ICommonService commonService)
        {
            _taskService = taskService;
            _commonService = commonService;
        }


        public async Task<ActionResult> Index(int pageNumber = 1, int pageSize = 10, string sortBy = "", string searchQuery = "")
        {
            try
            {
                var taskList = await _taskService.GetAllTasksAsync(pageNumber, pageSize, sortBy, searchQuery);

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
                var list = await _taskService.GetAllTasksAsync() ; // Assuming you have a method to get total task count
                var totalCount =list.Count();
                ViewBag.PageCount = (int)Math.Ceiling((double)totalCount / pageSize);

                return View(taskList);
            }
            catch (Exception ex)
            {
                // Log the exception
                return View("Error");
            }
        }



        // GET: TaskController/Details/5
        public async Task<ActionResult> TaskDetails(int id)
        {
            Models.Domain.Task taskDetail = await _taskService.GetTaskByIdAsync(id);
            if(taskDetail == null)
            {
                return View("Error"); ;
            }
            return View(taskDetail);
        }

        // GET: TaskController/Create
        public async Task<ActionResult> CreateTask()
        {
            ViewBag.Users = await _commonService.UserListAsync();
            ViewBag.Categories = await  _commonService.CategoryListAsync();
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTask(TaskDto task)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                    var isTaskCreated = await _taskService.CreateTaskAsync(task);

                    if (isTaskCreated)
                    {
                        return RedirectToAction("Index", "Task");
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
           
                return View("Error"); ;
                //Log the exception and rollback the transaction
               
            }
        }

        // GET: TaskController/Edit/5
        public async Task<ActionResult> EditTask(int id)
        {
            try
            {
                Models.Domain.Task taskEdit = await _taskService.GetTaskByIdAsync(id);
                if (taskEdit != null)
                {

                    ViewBag.Users = await _commonService.UserListAsync();
                    ViewBag.Categories = await _commonService.CategoryListAsync();
                    ViewBag.TaskID = taskEdit.TaskID;
                    return View(taskEdit);
                }
                else
                {
                    return View("Error");
                }
            }catch (Exception ex)
            {
                return View("Error");
            }
           
          
           
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTask(TaskDto task)
        {
            try{
                if (ModelState.IsValid)
                {
                    if (task != null)
                    {
                        var taskUpdate = await _taskService.UpdateTaskAsync(task);
                        if (taskUpdate)
                        {
                            return RedirectToAction("Index", "Task");
                        }
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                ViewBag.TaskID = task.TaskID;


                return View(task);
            } catch (Exception ex)
            {
                return View("Error");
            }
          

        }

        // GET: TaskController/Delete/5
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                Models.Domain.Task taskDel = await _taskService.GetTaskByIdAsync(id);
                return View(taskDel);
            }catch (Exception ex)
            {
                return View("Error");
            }
           
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               await _taskService.DeleteTaskAsync(id);
                return RedirectToAction("Index", "Task");
            }
            catch (Exception ex) 
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> ExportTasksToExcel()
        {
            try
            {
                // Call the ExportTasksToExcelAsync method from the TaskService
                var stream = await _taskService.ExportTasksToExcelAsync();

                // Define the file name for the Excel file
                string excelName = $"Tasks-{Guid.NewGuid()}.xlsx";

                // 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' is the MIME type for Excel files
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error view or message
                return View("Error");
            }
        }
    }
}
