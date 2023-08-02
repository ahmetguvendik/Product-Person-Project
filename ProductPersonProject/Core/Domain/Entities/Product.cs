using System;
namespace Domain.Entities
{
	public class Product : BaseEntity
	{
		public string SeriNo { get; set; }
		public bool Verildimi { get; set; }
		public string Info { get; set; }
		public Category Category { get; set; }
		public string CategoryId { get; set; }	
	}
}

