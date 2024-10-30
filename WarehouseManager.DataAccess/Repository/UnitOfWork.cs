﻿
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly WarehouseDbContext _context;

		public UnitOfWork(WarehouseDbContext context)
		{
			_context = context;
			Products = new EfRepository<Product>(_context);
			Orders = new EfRepository<Order>(_context);
			OrderItems = new EfRepository<OrderItem>(_context);
			PurchaseQueues = new EfRepository<PurchaseQueue>(_context);
		}

		public IRepository<Product> Products { get; }
		public IRepository<Order> Orders { get; }
		public IRepository<OrderItem> OrderItems { get; }
		public IRepository<PurchaseQueue> PurchaseQueues { get; }

		public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

		public void Dispose() => _context.Dispose();
	}
}
