using System;
using Application.CQRS.Commands.Person.RemovePerson;
using Application.CQRS.Commands.Product.CreateProduct;
using Application.CQRS.Commands.Product.RemoveProduct;
using Application.CQRS.Queries.Category.GetAllCategory;
using Application.CQRS.Queries.Product.GetProductCategory;
using Application.Repositories;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
          
        }
        public async Task<IActionResult> GetProduct(GetProductCategoryQueryRequest model)
        {
            var product = await _mediator.Send(model);
            return View(product);
        }

        public async Task<IActionResult> AddProduct(GetAllCategoryQueryRequest model)
        {
            var categories = await _mediator.Send(model);
            List<SelectListItem> values = (from c in categories.ToList() select new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
                
            }).ToList();

            ViewBag.Categories = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest model)
        {
            await _mediator.Send(model);
            return RedirectToAction("GetProduct", "Product");
        }

        public async Task<IActionResult> RemoveProduct(string id)
        {
            var removedProdut = new RemoveProductCommandRequest();
            removedProdut.Id = id;
            await _mediator.Send(removedProdut);
            return RedirectToAction("GetProduct", "Product");
        }
    }
}

