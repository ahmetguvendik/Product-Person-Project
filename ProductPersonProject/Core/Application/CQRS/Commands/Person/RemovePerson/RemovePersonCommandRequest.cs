using System;
using MediatR;

namespace Application.CQRS.Commands.Person.RemovePerson
{
	public class RemovePersonCommandRequest : IRequest<RemovePersonCommandResponse>
	{
		public string Id { get; set; }
		public string ProductId { get; set; }	
	}
}

