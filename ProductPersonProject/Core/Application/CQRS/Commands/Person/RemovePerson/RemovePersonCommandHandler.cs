using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Person.RemovePerson
{
	public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommandRequest,RemovePersonCommandResponse>
	{
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
		public RemovePersonCommandHandler(IPersonWriteRepository personWriteRepository,IProductReadRepository productReadRepository)
		{
            _personWriteRepository = personWriteRepository;
            _productReadRepository = productReadRepository;
		}

        public async Task<RemovePersonCommandResponse> Handle(RemovePersonCommandRequest request, CancellationToken cancellationToken)
        {
            await _personWriteRepository.RemoveAsync(request.Id);
            await _personWriteRepository.SaveAsync();
            return new RemovePersonCommandResponse();
        }
    }
}

