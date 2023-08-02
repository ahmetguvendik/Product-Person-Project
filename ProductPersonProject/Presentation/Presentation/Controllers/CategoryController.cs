using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.Category.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult GetCategory()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return View(response);
        }

    }
}

