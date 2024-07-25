using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDomain = TaskManagement.Core.Domains.Task;

namespace TaskManagement.Core.ViewModels
{
    public class IndexVM
    {
        public List<TaskDomain>? Tasks { get; set; }
        public CreateTaskVM? ViewModel { get; set; }
    }
}
