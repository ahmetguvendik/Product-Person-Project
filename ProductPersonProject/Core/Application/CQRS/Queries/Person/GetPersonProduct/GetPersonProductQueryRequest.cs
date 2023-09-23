using System;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.Person.GetPersonProduct
{
	public class GetPersonProductQueryRequest : IRequest<IQueryable<VM_Person_Product>>
	{
			
	}
}

