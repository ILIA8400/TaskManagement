using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.ViewModels
{
    public class CreateTaskVM
    {
        [Required(ErrorMessage ="موضوع نباید خالی باشه")]
        [MaxLength(55)]
        public string Title { get; set; }

        [MaxLength(55)]
        [Required(ErrorMessage = "توضیحات نباید خالی باشه")]
        public string Describtion { get; set; }

        [Required(ErrorMessage = "تاریخ شروع نباید خالی باشه")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "تاریخ پایان نباید خالی باشه")]
        public DateTime EndtDate { get; set; }

    }
}
