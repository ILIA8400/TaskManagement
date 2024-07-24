using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Commands;

namespace TaskManagement.Core.Handlers
{
    public class EditTaskHandler : IRequestHandler<EditTaskCommand, EditTaskResponse>
    {
        public Task<EditTaskResponse> Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
