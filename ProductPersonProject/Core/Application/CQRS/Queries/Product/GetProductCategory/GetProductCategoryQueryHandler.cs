using System;
using Application.Services;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.Product.GetProductCategory
{
	public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQueryRequest, IQueryable<VM_Product_Category>>
	{
        private readonly IProductService _productService;
		public GetProductCategoryQueryHandler(IProductService productService)
		{
            _productService = productService;
		}

        public async Task<IQueryable<VM_Product_Category>> Handle(GetProductCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _productService.GetProductCategory();
            return response;
        }
    }
}

