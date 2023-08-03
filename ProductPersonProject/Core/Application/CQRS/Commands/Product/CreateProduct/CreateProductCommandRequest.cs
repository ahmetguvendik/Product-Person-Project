using MediatR;
namespace Application.CQRS.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
	{
		public string Name { get; set; }
		public string SeriNo { get; set; }
		public string Info { get; set; }
		public string CategoryId { get; set; }

	}
}

