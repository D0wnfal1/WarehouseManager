using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.BusinessLogic.Services
{
    public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Order>> GetAllOrdersAsync()
		{
			return await _unitOfWork.Orders.GetAllWithItemsAsync(); 
		}

		public async Task<Order> GetOrderByIdAsync(int id)
		{
			return await _unitOfWork.Orders.GetByIdWithItemsAsync(id);
		}

		public async Task CreateOrderAsync(Order order)
		{
			await _unitOfWork.Orders.AddAsync(order);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task CompleteOrderAsync(int orderId)
		{
			var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
			if (order != null)
			{
				order.IsCompleted = true;
				await _unitOfWork.Orders.UpdateAsync(order);
			}
		}

		public async Task DeleteOrderAsync(int id)
		{
			var order = await _unitOfWork.Orders.GetByIdAsync(id);
			if (order != null)
			{
				await _unitOfWork.Orders.DeleteAsync(order);
			}
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
