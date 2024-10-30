using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.BusinessLogic.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetAllOrdersAsync();
		Task<Order> GetOrderByIdAsync(Guid id);
		Task CreateOrderAsync(Order order);
		Task CompleteOrderAsync(Guid orderId);
		Task DeleteOrderAsync(Guid id);
	}
}
