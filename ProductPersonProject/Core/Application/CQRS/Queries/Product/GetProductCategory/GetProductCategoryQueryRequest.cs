using System;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.Product.GetProductCategory
{
	public class GetProductCategoryQueryRequest : IRequest<IQueryable<VM_Product_Category>>
	{
		
	}
}

