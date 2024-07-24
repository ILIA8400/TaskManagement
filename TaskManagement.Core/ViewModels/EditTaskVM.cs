using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.ViewModels
{
    public class EditTaskVM
    {
        [MaxLength(55)]
        public string? Title { get; set; }

        [MaxLength(55)]
        public string? Describtion { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndtDate { get; set; }
    }
}
