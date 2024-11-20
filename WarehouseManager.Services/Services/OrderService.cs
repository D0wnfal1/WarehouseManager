using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.BusinessLogic.Services
{
    public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductService _productService;

		public OrderService(IUnitOfWork unitOfWork, IProductService productService)
		{
			_unitOfWork = unitOfWork;
			_productService = productService;
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

		public async Task<Result> CompleteOrderAsync(int orderId)
		{
			var order = await _unitOfWork.Orders.GetByIdWithItemsAsync(orderId);

			if (order == null)
			{
				return Result.Failure($"Order with ID {orderId} does not exist.");
			}

			if (order.IsCompleted)
			{
				return Result.Failure($"Order with ID {orderId} is already completed.");
			}

			foreach (var item in order.Items)
			{
				var product = await _productService.GetProductByIdAsync(item.ProductId);
				if (product == null)
				{
					return Result.Failure($"Product with ID {item.ProductId} does not exist.");
				}

				if (product.Stock < item.Quantity)
				{
					return Result.Failure(
						$"Not enough stock for product ID {product.Id}. Required: {item.Quantity}, Available: {product.Stock}."
					);
				}

				product.Stock -= item.Quantity;
				await _productService.UpdateProductAsync(product);
			}

			order.IsCompleted = true;
			await _unitOfWork.SaveChangesAsync();

			return Result.Success();
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
