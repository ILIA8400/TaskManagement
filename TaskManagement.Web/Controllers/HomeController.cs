using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagement.Core.Commands;
using TaskManagement.Core.Queries;
using TaskManagement.Core.ViewModels;
using TaskManagement.Web.Models;

namespace TaskManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _mediator.Send(new GetTaskQuery());

            var model = new IndexVM
            {
                Tasks = tasks,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateTaskVM model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateTaskCommand
                {
                    Title = model.Title,
                    Describtion = model.Describtion,
                    StartDate = model.StartDate,
                    EndtDate = model.EndtDate
                };

                var tasks = await _mediator.Send(command);

                var vm = new IndexVM
                {
                    Tasks = tasks
                };
                return View();
            }
            else return View(model);
            
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditTaskVM model)
        {
            var command = new EditTaskCommand
            {
                Title = model.Title,
                Describtion = model.Describtion,
                StartDate = model.StartDate,
                EndtDate = model.EndtDate
            };
            var result = await _mediator.Send(command);

            return View(viewName: "Index", model: result);
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(EditTaskVM model)
        //{
        //    var command = new DeleteTaskCommand();
            
        //    var result = await _mediator.Send(command);

        //    return View(viewName: "Index");
        //}

    }
}
