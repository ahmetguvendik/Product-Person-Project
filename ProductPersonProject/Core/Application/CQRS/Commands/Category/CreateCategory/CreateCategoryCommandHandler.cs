using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Category.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,CreateCategoryCommandResponse>
	{
        private readonly ICategoryWriteRepository _writeRepository;
		public CreateCategoryCommandHandler(ICategoryWriteRepository writeRepository)
		{
            _writeRepository = writeRepository;
		}

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category();
            category.Id = Guid.NewGuid().ToString();
            category.Name = request.Name;
            await _writeRepository.AddAsync(category);
            await _writeRepository.SaveAsync();

            return new CreateCategoryCommandResponse()
            {
                Name = request.Name
            };
        }
    }
}

