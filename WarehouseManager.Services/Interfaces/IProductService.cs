﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.BusinessLogic.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task<Product> GetProductByIdAsync(int id);
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
	}
}
