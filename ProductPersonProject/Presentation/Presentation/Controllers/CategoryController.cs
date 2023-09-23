using Application.CQRS.Commands.Category.CreateCategory;
using Application.CQRS.Commands.Category.RemoveCategory;
using Application.CQRS.Queries.Category.GetAllCategory;
using Application.Repositories;
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
        public async Task<IActionResult> GetCategory(GetAllCategoryQueryRequest model)
        {
            var categories = await _mediator.Send(model);
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return RedirectToAction("GetCategory", "Category"); 
        }

        public async Task<IActionResult> RemoveCategory(string id)
        {
            var removedCategory = new RemoveCategoryCommandRequest();
            removedCategory.Id = id;
            await _mediator.Send(removedCategory);
            return RedirectToAction("GetCategory", "Category");
        }

    }
}

