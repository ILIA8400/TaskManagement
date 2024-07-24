using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Commands;
using TaskDomain = TaskManagement.Core.Domains.Task;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Core.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, List<TaskDomain>>
    {
        private readonly ITaskRepository _repository;

        public CreateTaskHandler(ITaskRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<TaskDomain>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var newTask = new TaskDomain
            {
                Title = request.Title,
                Description = request.Describtion,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            await _repository.AddTaskAsync(newTask);
            return await _repository.GetTasksAsync();
        }
    }
}
