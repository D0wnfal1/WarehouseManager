using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Product> Products { get; }
		IRepository<Order> Orders { get; }
		IRepository<OrderItem> OrderItems { get; }
		IRepository<PurchaseQueue> PurchaseQueues { get; }
		Task<int> SaveChangesAsync();
	}
}
