using System;
using MediatR;

namespace Application.CQRS.Commands.Category.RemoveCategory
{
	public class RemoveCategoryCommandRequest : IRequest<RemoveCategoryCommandResponse>
	{
		public string Id { get; set; }	
	}
}

