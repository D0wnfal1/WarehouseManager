using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.EfRepository;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.DataAccess.Repository
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
	{
		private readonly WarehouseDbContext _context;
		public ProductRepository(WarehouseDbContext context) : base(context) { }

		public async Task<IEnumerable<Product>> GetAllAvailableProductsAsync()
		{
			return await _context.Products
				.Where(p => p.Stock > 0) 
				.ToListAsync();
		}
	}
}
