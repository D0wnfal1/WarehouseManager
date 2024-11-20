using Microsoft.EntityFrameworkCore;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.DataAccess.EfRepository
{
    public class PurchaseQueueRepository : EfRepository<PurchaseQueue>, IPurchaseQueueRepository
	{
		private readonly WarehouseDbContext _context;
		public PurchaseQueueRepository(WarehouseDbContext context) : base(context) 
		{
			_context = context;
		}

		public async Task<List<Product>> GetLowStockProductsAsync()
		{
			var threshold = 10; 
			var lowStockProducts = await _context.Products
				.Where(p => p.Stock < threshold)
				.ToListAsync();

			return lowStockProducts;
		}

		public async Task<PurchaseQueue> GetPurchaseQueueByProductIdAsync(int productId)
		{
			var purchaseQueue = await _context.PurchaseQueues
				.FirstOrDefaultAsync(pq => pq.ProductId == productId);

			return purchaseQueue;
		}
	}
}
