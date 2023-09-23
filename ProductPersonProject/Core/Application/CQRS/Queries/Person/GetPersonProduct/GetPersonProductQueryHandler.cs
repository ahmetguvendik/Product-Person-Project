using System;
using Application.Services;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.Person.GetPersonProduct
{
	public class GetPersonProductQueryHandler : IRequestHandler<GetPersonProductQueryRequest, IQueryable<VM_Person_Product>>
	{
        private readonly IPersonService _personService;
		public GetPersonProductQueryHandler(IPersonService personService)
		{
            _personService = personService;
		}

        public async Task<IQueryable<VM_Person_Product>> Handle(GetPersonProductQueryRequest request, CancellationToken cancellationToken)
        {
            var people = _personService.GetPersonProduct();
            return people;
        }
    }
}

