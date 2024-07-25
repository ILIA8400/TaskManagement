using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Commands;
using TaskManagement.Core.Interfaces;
using TaskDomain = TaskManagement.Core.Domains.Task;

namespace TaskManagement.Core.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, List<TaskDomain>>
    {
        private readonly ITaskRepository _repository;

        public DeleteTaskHandler(ITaskRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<TaskDomain>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteTaskAsync(request.Title);
            return await _repository.GetTasksAsync();
        }
    }
}
