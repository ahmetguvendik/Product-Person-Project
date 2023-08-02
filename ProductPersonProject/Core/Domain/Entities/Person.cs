using System;
namespace Domain.Entities
{
	public class Person : BaseEntity
	{
	
		public string Surname { get; set; }
		public string Info { get; set; }
		public List<Product> Products { get; set; }
		public string ProductId { get; set; }	
	}
}

