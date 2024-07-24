using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskDomain = TaskManagement.Core.Domains.Task;

namespace TaskManagement.Core.Commands
{
    public class CreateTaskCommand : IRequest<List<TaskDomain>>
    {
        public string Title { get; set; }
        public string Describtion { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
    }



}
