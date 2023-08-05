using System;
namespace Application.CQRS.Commands.Person.CreatePerson
{
	public class CreatePersonCommandResponse
	{
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Info { get; set; }
        public string ProductId { get; set; }
    }
}

