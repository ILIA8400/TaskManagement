using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDomain = TaskManagement.Core.Domains.Task;

namespace TaskManagement.Core.Commands
{
    public class DeleteTaskCommand : IRequest<List<TaskDomain>>
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
    }
}
