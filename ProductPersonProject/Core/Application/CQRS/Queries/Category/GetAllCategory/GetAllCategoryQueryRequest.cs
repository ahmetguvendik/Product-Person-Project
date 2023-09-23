using System;
using MediatR;

namespace Application.CQRS.Queries.Category.GetAllCategory
{
	public class GetAllCategoryQueryRequest : IRequest<IQueryable<Domain.Entities.Category>>
	{
		
	}
}

