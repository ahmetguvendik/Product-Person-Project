using System;
using MediatR;

namespace Application.CQRS.Commands.Category.CreateCategory
{
	public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
	{
		public string Name { get; set; }	
	}
}

