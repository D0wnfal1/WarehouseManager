using Microsoft.AspNetCore.Mvc;
using WarehouseManager.BusinessLogic.Services;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.WebHost.DTOs;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
	private readonly IOrderService _orderService;

	public OrderController(IOrderService orderService)
	{
		_orderService = orderService;
	}

	/// <summary>
	/// Retrieves a list of all orders.
	/// </summary>
	/// <returns>List of OrderDto objects.</returns>
	/// <response code="200">Returns the list of orders.</response>
	[HttpGet]
	public async Task<IActionResult> GetOrders()
	{
		var orders = await _orderService.GetAllOrdersAsync();
		var orderDtos = orders.Select(o => new OrderDto
		{
			Id = o.Id,
			OrderDate = o.OrderDate,
			IsCompleted = o.IsCompleted,
			Items = o.Items.Select(i => new OrderItemDto
			{
				Id = i.Id,
				ProductId = i.ProductId,
				Quantity = i.Quantity
			}).ToList()
		});
		return Ok(orderDtos);
	}

	/// <summary>
	/// Creates a new order.
	/// </summary>
	/// <param name="orderDto">OrderDto object containing the order details.</param>
	/// <returns>OrderDto object of the created order.</returns>
	/// <response code="201">Returns the created order.</response>
	[HttpPost]
	public async Task<IActionResult> CreateOrder([FromForm] OrderDto orderDto)
	{
		var order = new Order
		{
			Id = Guid.NewGuid(),
			OrderDate = DateTime.UtcNow,
			IsCompleted = false,
			Items = orderDto.Items.Select(i => new OrderItem
			{
				Id = Guid.NewGuid(),
				ProductId = i.ProductId,
				Quantity = i.Quantity
			}).ToList()
		};
		await _orderService.CreateOrderAsync(order);
		return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, orderDto);
	}

	/// <summary>
	/// Retrieves an order by its ID.
	/// </summary>
	/// <param name="id">Order ID.</param>
	/// <returns>OrderDto object with the specified ID.</returns>
	/// <response code="200">Returns the order.</response>
	/// <response code="404">If the order is not found.</response>
	[HttpGet("{id}")]
	public async Task<IActionResult> GetOrderById(Guid id)
	{
		var order = await _orderService.GetOrderByIdAsync(id);
		if (order == null) return NotFound();

		var orderDto = new OrderDto
		{
			Id = order.Id,
			OrderDate = order.OrderDate,
			Items = order.Items.Select(i => new OrderItemDto
			{
				Id = i.Id,
				ProductId = i.ProductId,
				Quantity = i.Quantity
			}).ToList(),
			IsCompleted = order.IsCompleted
		};
		return Ok(orderDto);
	}

	/// <summary>
	/// Marks an order as completed.
	/// </summary>
	/// <param name="id">Order ID.</param>
	/// <response code="204">If the order was successfully completed.</response>
	[HttpPut("{id}/complete")]
	public async Task<IActionResult> CompleteOrder(Guid id)
	{
		await _orderService.CompleteOrderAsync(id);
		return NoContent();
	}

	/// <summary>
	/// Deletes an order by its ID.
	/// </summary>
	/// <param name="id">Order ID.</param>
	/// <response code="204">If the order was successfully deleted.</response>
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteOrder(Guid id)
	{
		await _orderService.DeleteOrderAsync(id);
		return NoContent();
	}
}
