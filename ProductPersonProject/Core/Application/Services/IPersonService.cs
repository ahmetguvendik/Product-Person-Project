using System;
using Application.ViewModels;

namespace Application.Services
{
	public interface IPersonService
	{
		IQueryable<VM_Person_Product> GetPersonProduct();	
	}
}

