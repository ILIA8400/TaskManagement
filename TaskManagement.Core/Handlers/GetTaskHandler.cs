using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Core.Queries;
using TaskDomain = TaskManagement.Core.Domains.Task;

namespace TaskManagement.Core.Handlers
{
    public class GetTaskHandler : IRequestHandler<GetTaskQuery, List<TaskDomain>>
    {
        private readonly ITaskRepository _repository;

        public GetTaskHandler(ITaskRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<TaskDomain>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetTasksAsync();
            return tasks;
        }
    }
}
