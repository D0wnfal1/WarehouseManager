using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.EfRepository;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.DataAccess.Repository
{
    public class OrderItemRepository : EfRepository<OrderItem>
	{
		private readonly WarehouseDbContext _context;
		public OrderItemRepository(WarehouseDbContext context) : base(context) { }

		public async Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(Guid orderId)
		{
			return await _context.OrderItems
				.Where(oi => oi.OrderId == orderId)
				.ToListAsync();
		}
	}
}
