using Application.CQRS.Commands.Category.CreateCategory;
using Application.CQRS.Commands.Category.RemoveCategory;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICategoryReadRepository _categoryReadRepository;
        public CategoryController(IMediator mediator,ICategoryReadRepository categoryReadRepository)
        {
            _mediator = mediator;
            _categoryReadRepository = categoryReadRepository;
        }
        public IActionResult GetCategory()
        {
            var categories = _categoryReadRepository.GetAll();
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

