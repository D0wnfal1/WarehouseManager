using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.DataAccess.EfRepository
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
	{
		private readonly WarehouseDbContext _context;
		public OrderRepository(WarehouseDbContext context) : base(context) 
		{
			_context = context;
		}

		public async Task<Order> GetByIdWithItemsAsync(Guid id)
		{
			return await _context.Orders
				.Include(o => o.Items)
				.FirstOrDefaultAsync(o => o.Id == id);
		}

		public async Task<IEnumerable<Order>> GetAllWithItemsAsync()
		{
			return await _context.Orders
				.Include(o => o.Items)
				.ToListAsync();
		}
	}
}
