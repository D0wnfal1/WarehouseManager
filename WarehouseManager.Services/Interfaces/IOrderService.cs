using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.BusinessLogic.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetAllOrdersAsync();
		Task<Order> GetOrderByIdAsync(int id);
		Task CreateOrderAsync(Order order);
		Task<Result> CompleteOrderAsync(int orderId);
		Task DeleteOrderAsync(int id);
	}
}
