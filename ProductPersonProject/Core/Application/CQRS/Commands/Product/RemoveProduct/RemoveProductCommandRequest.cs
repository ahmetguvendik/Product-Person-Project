using System;
using MediatR;

namespace Application.CQRS.Commands.Product.RemoveProduct
{
	public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
	{
		public string Id { get; set; }	
	}
}

