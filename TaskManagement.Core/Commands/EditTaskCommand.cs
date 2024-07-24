using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Commands
{
    public class EditTaskCommand : IRequest<EditTaskResponse>
    {
        public string? Title { get; set; }

        public string? Describtion { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndtDate { get; set; }
    }

    public class EditTaskResponse
    {
        public string? Title { get; set;}
    }
}
