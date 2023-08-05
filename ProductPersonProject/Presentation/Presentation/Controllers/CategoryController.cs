using Application.CQRS.Commands.Category.CreateCategory;
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

    }
}

