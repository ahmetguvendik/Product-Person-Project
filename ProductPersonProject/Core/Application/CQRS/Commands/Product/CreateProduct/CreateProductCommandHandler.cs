using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Product.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,CreateProductCommandResponse>
	{
        private readonly IProductWriteRepository _productWriteRepository;
		public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
		{
            _productWriteRepository = productWriteRepository;
		}

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product();
            product.Id = Guid.NewGuid().ToString();
            product.Verildimi = false;
            product.Name = request.Name;
            product.Info = request.Info;
            product.SeriNo = request.SeriNo;
            product.CategoryId = request.CategoryId; 
            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();
            return new CreateProductCommandResponse()
            {
                Name = request.Name,
                Info = request.Info,
                SeriNo = request.SeriNo,
                CategoryId = request.CategoryId
                
            };
        }
    }
}

