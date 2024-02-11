using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using MVCProject.Models.DTO;
using MVCProject.Repository.Interfaces;

namespace MVCProject.Repository.Implemenentaion
{
    public class TaskRepository : GenericRepository<Models.Domain.Task>, ITaskRepository
    {
        public TaskRepository(TaskDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Models.Domain.Task>> GetTaskByNameAsync(string taskName)
        {
            return await _dbSet.Where(p => p.Title.Contains(taskName)).ToListAsync();
        }

        public class ExcelFileHandling
        {
            //This Method will Create an Excel Sheet and Store it in the Memory Stream Object
            //And return thar Memory Stream Object
            public MemoryStream CreateExcelFile(IEnumerable<Models.Domain.Task> tasks)
            {
                //Create an Instance of Workbook, i.e., Creates a new Excel workbook
                var workbook = new XLWorkbook();
                //Add a Worksheets with the workbook
                //Worksheets name is Employees
                IXLWorksheet worksheet = workbook.Worksheets.Add("Task");
                //Create the Cell
                //First Row is going to be Header Row
                worksheet.Cell(1, 1).Value = "ID"; // First Row and First Column
                worksheet.Cell(1, 2).Value = "Title"; // First Row and Second Column
                worksheet.Cell(1, 3).Value = "Description"; // First Row and Third Column
                worksheet.Cell(1, 4).Value = "Due Date"; // First Row and Fourth Column
                worksheet.Cell(1, 5).Value = "Is Completed"; // First Row and Fifth Column
                worksheet.Cell(1, 6).Value = "User ID"; // First Row and Sixth Column
                worksheet.Cell(1, 7).Value = "Category ID"; // First Row and Seventh Column
                                                            //Data is going to stored from Row 2
                int row = 2;
                //Loop Through Each Employees and Populate the worksheet
                //For Each Employee increase row by 1
                foreach (var task in tasks)
                {
                    worksheet.Cell(row, 1).Value = task.TaskID;
                    worksheet.Cell(row, 2).Value = task.Title;
                    worksheet.Cell(row, 3).Value = task.Description;
                    worksheet.Cell(row, 4).Value = task.DueDate;
                    worksheet.Cell(row, 5).Value = task.IsCompleted;
                    worksheet.Cell(row, 6).Value = task.UserId;
                    worksheet.Cell(row, 7).Value = task.CategoryId;
                    row++; // Increase the Data Row by 1
                }
                //Create an Memory Stream Object
                var stream = new MemoryStream();
                //Saves the current workbook to the Memory Stream Object.
                workbook.SaveAs(stream);
                //The Position property gets or sets the current position within the stream.
                //This is the next position a read, write, or seek operation will occur from.
                stream.Position = 0;
                return stream;
            }

        }
    }
}