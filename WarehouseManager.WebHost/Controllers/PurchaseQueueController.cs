using Microsoft.AspNetCore.Mvc;
using WarehouseManager.BusinessLogic.Services;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.WebHost.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PurchaseQueueController : ControllerBase
{
	private readonly IPurchaseQueueService _purchaseQueueService;

	public PurchaseQueueController(IPurchaseQueueService purchaseQueueService)
	{
		_purchaseQueueService = purchaseQueueService;
	}

	[HttpGet]
	public async Task<IActionResult> GetPurchaseQueues()
	{
		var purchaseQueues = await _purchaseQueueService.GetAllPurchaseQueuesAsync();
		return Ok(purchaseQueues.Select(pq => new PurchaseQueueDto
		{
			Id = pq.Id,
			ProductId = pq.ProductId,
			Quantity = pq.Quantity
		}));
	}

	[HttpPost]
	public async Task<IActionResult> AddToPurchaseQueue([FromBody] PurchaseQueueDto purchaseQueueDto)
	{
		var purchaseQueue = new PurchaseQueue
		{
			Id = Guid.NewGuid(),
			ProductId = purchaseQueueDto.ProductId,
			Quantity = purchaseQueueDto.Quantity
		};

		await _purchaseQueueService.AddToPurchaseQueueAsync(purchaseQueue);
		return CreatedAtAction(nameof(GetPurchaseQueueById), new { id = purchaseQueue.Id }, purchaseQueueDto);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetPurchaseQueueById(Guid id)
	{
		var purchaseQueue = await _purchaseQueueService.GetPurchaseQueueByIdAsync(id);
		if (purchaseQueue == null) return NotFound();

		var purchaseQueueDto = new PurchaseQueueDto
		{
			Id = purchaseQueue.Id,
			ProductId = purchaseQueue.ProductId,
			Quantity = purchaseQueue.Quantity
		};

		return Ok(purchaseQueueDto);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> RemoveFromPurchaseQueue(Guid id)
	{
		await _purchaseQueueService.RemoveFromPurchaseQueueAsync(id);
		return NoContent();
	}
}
