using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.BusinessLogic.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetAllOrdersAsync();
		Task<Order> GetOrderByIdAsync(int id);
		Task CreateOrderAsync(Order order);
		Task CompleteOrderAsync(int orderId);
		Task DeleteOrderAsync(int id);
	}
}
