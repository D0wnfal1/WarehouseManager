using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.BusinessLogic.Services
{
    public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync()
		{
			return await _unitOfWork.Products.GetAllAsync();
		}

		public async Task<Product> GetProductByIdAsync(Guid id)
		{
			return await _unitOfWork.Products.GetByIdAsync(id);
		}

		public async Task AddProductAsync(Product product)
		{
			await _unitOfWork.Products.AddAsync(product);
		}

		public async Task UpdateProductAsync(Product product)
		{
			await _unitOfWork.Products.UpdateAsync(product);
		}

		public async Task DeleteProductAsync(Guid id)
		{
			var product = await _unitOfWork.Products.GetByIdAsync(id);
			if (product != null)
			{
				await _unitOfWork.Products.DeleteAsync(product);
			}
		}
	}
}
