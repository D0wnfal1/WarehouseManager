
using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.DataAccess.EfRepository
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly WarehouseDbContext _context;

		public UnitOfWork(WarehouseDbContext context)
		{
			_context = context;
			Products = new EfRepository<Product>(_context);
			Orders = new OrderRepository(_context);
			OrderItems = new EfRepository<OrderItem>(_context);
			PurchaseQueues = new PurchaseQueueRepository(_context);
		}

		public IRepository<Product> Products { get; }
		public IOrderRepository Orders { get; }
		public IRepository<OrderItem> OrderItems { get; }
		public IPurchaseQueueRepository PurchaseQueues { get; }

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
		   _context.Dispose();
		}
	}
}
