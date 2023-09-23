using Application.CQRS.Commands.Person.CreatePerson;
using Application.CQRS.Commands.Person.RemovePerson;
using Application.CQRS.Queries.Person.GetPersonProduct;
using Application.CQRS.Queries.Product.GetAllProduct;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
                _mediator = mediator;
        }   
        public async Task<IActionResult> GetPerson(GetPersonProductQueryRequest model)
        {
            var people = await _mediator.Send(model);
            return View(people);
        }

        public async Task<IActionResult> AddPerson(GetAllProductQueryRequest model)
        {
            var products = await _mediator.Send(model);
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

