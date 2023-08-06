﻿using System;
using Application.CQRS.Commands.Person.RemovePerson;
using Application.CQRS.Commands.Product.CreateProduct;
using Application.CQRS.Commands.Product.RemoveProduct;
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
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IProductService _productService;
        private readonly IMediator _mediator;
        public ProductController(ICategoryReadRepository categoryReadRepository,IMediator mediator,IProductService productService)
        {
            _categoryReadRepository = categoryReadRepository;
            _mediator = mediator;
            _productService = productService;
          
        }
        public IActionResult GetProduct()
        {
           var product =  _productService.GetProductCategory();
            return View(product);
        }

        public IActionResult AddProduct()
        {
            var categories = _categoryReadRepository.GetAll();
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
            var response = await _mediator.Send(model);
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

