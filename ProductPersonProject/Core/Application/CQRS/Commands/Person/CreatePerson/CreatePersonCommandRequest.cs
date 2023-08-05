using System;
using MediatR;

namespace Application.CQRS.Commands.Person.CreatePerson
{
	public class CreatePersonCommandRequest :IRequest<CreatePersonCommandResponse>
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public string Info { get; set; }
		public string ProductId { get; set; }	
	}
}

