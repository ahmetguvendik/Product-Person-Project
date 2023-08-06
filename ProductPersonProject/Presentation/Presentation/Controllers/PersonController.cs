using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.Category.RemoveCategory;
using Application.CQRS.Commands.Person.CreatePerson;
using Application.CQRS.Commands.Person.RemovePerson;
using Application.Repositories;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IPersonService _personService;
        public PersonController(IMediator mediator,IProductReadRepository productReadRepository,IPersonService personService)
        {
                _mediator = mediator;
                _productReadRepository = productReadRepository;
                _personService = personService;
        }   
        public IActionResult GetPerson()
        {
            var people = _personService.GetPersonProduct();
            return View(people);
        }

        public IActionResult AddPerson()
        {
            var products = _productReadRepository.GetAll();
            List<SelectListItem> values = (from c in products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = c.Name,
                                               Value = c.Id.ToString()

                                           }).ToList();

            ViewBag.Categories = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(CreatePersonCommandRequest model)
        {
            await _mediator.Send(model);
            return RedirectToAction("GetPerson", "Person");
        }

        public async Task<IActionResult> RemovePerson(string id)
        {
            var removedPerson = new RemovePersonCommandRequest();
            removedPerson.Id = id;
            await _mediator.Send(removedPerson);
            return RedirectToAction("GetPerson", "Person");
        }
    }
}

