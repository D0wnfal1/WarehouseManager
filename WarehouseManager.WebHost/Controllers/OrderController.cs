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

	[HttpPost]
	public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
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

	[HttpPut("{id}/complete")]
	public async Task<IActionResult> CompleteOrder(Guid id)
	{
		await _orderService.CompleteOrderAsync(id);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteOrder(Guid id)
	{
		await _orderService.DeleteOrderAsync(id);
		return NoContent();
	}
}
