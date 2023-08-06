using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Person.CreatePerson
{
	public class CreateProductCommandHandler : IRequestHandler<CreatePersonCommandRequest,CreatePersonCommandResponse>
	{
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
		public CreateProductCommandHandler(IPersonWriteRepository personWriteRepository,IProductReadRepository productReadRepository)
		{
            _personWriteRepository = personWriteRepository;
            _productReadRepository = productReadRepository;
		}

        public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.Person();
            person.Id = Guid.NewGuid().ToString();
            person.Name = request.Name;
            person.Surname = request.SurName;
            person.Info = request.Info;
            person.ProductId = request.ProductId;
            var product = await _productReadRepository.GetById(request.ProductId);
            product.Verildimi = true;
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

