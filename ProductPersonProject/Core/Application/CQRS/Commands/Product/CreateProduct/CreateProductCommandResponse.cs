using System;
namespace Application.CQRS.Commands.Product.CreateProduct
{
	public class CreateProductCommandResponse
	{
        public string Name { get; set; }
        public string SeriNo { get; set; }
        public string Info { get; set; }
        public string CategoryId { get; set; }
    }
}

