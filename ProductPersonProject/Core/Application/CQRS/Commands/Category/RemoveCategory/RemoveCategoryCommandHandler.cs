using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Category.RemoveCategory
{
	public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest,RemoveCategoryCommandResponse>
	{
        private readonly ICategoryWriteRepository _categoryWriteRepository;
		public RemoveCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
		{
            _categoryWriteRepository = categoryWriteRepository;
		}

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryWriteRepository.RemoveAsync(request.Id);
            await _categoryWriteRepository.SaveAsync();
            return new RemoveCategoryCommandResponse();
        }
    }
}

