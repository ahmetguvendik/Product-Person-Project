using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Person.CreatePerson
{
	public class CreateProductCommandHandler : IRequestHandler<CreatePersonCommandRequest,CreatePersonCommandResponse>
	{
        private readonly IPersonWriteRepository _personWriteRepository;
		public CreateProductCommandHandler(IPersonWriteRepository personWriteRepository)
		{
            _personWriteRepository = personWriteRepository;
		}

        public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.Person();
            person.Id = Guid.NewGuid().ToString();
            person.Name = request.Name;
            person.Surname = request.SurName;
            person.Info = request.Info;
            person.ProductId = request.ProductId;
            await _personWriteRepository.AddAsync(person);
            await _personWriteRepository.SaveAsync();
            return new CreatePersonCommandResponse()
            {
                Name = request.Name,
                Info = request.Info,
                ProductId = request.ProductId,
                SurName = request.SurName
            };
        }
    }
}

