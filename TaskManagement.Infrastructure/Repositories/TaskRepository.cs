using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.Data;
using TaskDomain = TaskManagement.Core.Domains.Task;
using TaskEntity = TaskManagement.Infrastructure.Data.Entities.Task;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManDbContext _context;

        public TaskRepository(TaskManDbContext context)
        {
            this._context = context;
        }

        public async Task<int> AddTaskAsync(TaskDomain task)
        {
            var myTask = new TaskEntity
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate
            };

            await _context.Tasks.AddAsync(myTask);
            await _context.SaveChangesAsync();

            return task.TaskId;
        }

        public async Task DeleteTaskAsync(string title)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(t => t.Title == title);
            if (task != null)
            {
                _context.Remove(task);
                await _context.SaveChangesAsync();
            }
            else throw new Exception("Not found");
        }

        public async Task<TaskDomain> GetTaskByIdAsync(int id)
        {
            var result = await _context.Tasks.Where(c=>c.TaskId == id).Select(c=> new TaskDomain
            {
                TaskId = c.TaskId,
                Title = c.Title, 
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }).SingleOrDefaultAsync(c=> c.TaskId == id);

            if (result != null) return result;
            else throw new Exception(message: "value is null");
            
        }

        public async Task<List<TaskDomain>> GetTasksAsync()
        {
            return await _context.Tasks.Select(c => new TaskDomain
            {
                TaskId = c.TaskId,
                Title = c.Title,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }).ToListAsync();
        }

        public async Task UpdateTaskAsync(TaskDomain task)
        {
            var myTask = new TaskEntity
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate
            };

             _context.Update(myTask);
            await _context.SaveChangesAsync();         

        }
    }
}
