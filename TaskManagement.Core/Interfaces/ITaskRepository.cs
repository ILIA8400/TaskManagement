using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDomain = TaskManagement.Core.Domains.Task;

namespace TaskManagement.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskDomain>> GetTasksAsync();
        Task<TaskDomain> GetTaskByIdAsync(int id);
        Task<int> AddTaskAsync(TaskDomain task);
        Task UpdateTaskAsync(TaskDomain task);
        Task DeleteTaskAsync(string title,DateTime startTime);
    }
}
