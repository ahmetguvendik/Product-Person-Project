using System;
using Application.ViewModels;

namespace Application.Services
{
	public interface IProductService
	{
		IQueryable<VM_Product_Category> GetProductCategory();	
	}
}

