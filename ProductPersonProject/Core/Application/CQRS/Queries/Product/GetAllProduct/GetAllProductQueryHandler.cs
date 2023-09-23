using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Product.GetAllProduct
{
	public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest,IQueryable<Domain.Entities.Product>>
	{
        private readonly IProductReadRepository _productReadRepository;
		public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
		{
            _productReadRepository = productReadRepository;
		}

        public async Task<IQueryable<Domain.Entities.Product>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _productReadRepository.GetAll();
            return value;
        }
    }
}

