using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Category.GetAllCategory
{
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest,IQueryable<Domain.Entities.Category>>
	{
        private readonly ICategoryReadRepository _categoryReadRepository;
		public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
		{
            _categoryReadRepository = categoryReadRepository;
		}

        public async Task<IQueryable<Domain.Entities.Category>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _categoryReadRepository.GetAll();
            return value;
        }
    }
}

