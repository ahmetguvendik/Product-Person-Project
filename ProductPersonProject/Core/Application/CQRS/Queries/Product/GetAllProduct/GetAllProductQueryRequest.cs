using System;
using MediatR;

namespace Application.CQRS.Queries.Product.GetAllProduct
{
	public class GetAllProductQueryRequest : IRequest<IQueryable<Domain.Entities.Product>>
	{
		public GetAllProductQueryRequest()
		{
		}
	}
}

