using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDomain = TaskManagement.Core.Domains.Task;
namespace TaskManagement.Core.Queries
{
    public class GetTaskQuery : IRequest<List<TaskDomain>>
    {
    }
}
