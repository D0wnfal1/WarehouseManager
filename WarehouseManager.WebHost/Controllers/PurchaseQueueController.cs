using Microsoft.AspNetCore.Mvc;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.WebHost.DTOs;
using WarehouseManager.BusinessLogic.Services;

[ApiController]
[Route("api/[controller]")]
public class PurchaseQueueController : ControllerBase
{
	private readonly IPurchaseQueueService _purchaseQueueService;

	public PurchaseQueueController(IPurchaseQueueService purchaseQueueService)
	{
		_purchaseQueueService = purchaseQueueService;
	}

	/// <summary>
	/// Gets a list of all purchase queue items.
	/// </summary>
	/// <returns>A list of purchase queue items.</returns>
	/// <response code="200">Returns the list of purchase queue items.</response>
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

	/// <summary>
	/// Adds a new item to the purchase queue.
	/// </summary>
	/// <param name="purchaseQueueDto">The purchase queue item details.</param>
	/// <returns>The newly created purchase queue item.</returns>
	/// <response code="201">Returns the newly created item.</response>
	/// <response code="400">If the item data is invalid.</response>
	/// <remarks>
	/// Sample request:
	///
	///     POST /api/purchasequeue
	///     {
	///        "productId": "abcd1234-5678-90ef-1234-567890abcdef",
	///        "quantity": 10
	///     }
	///
	/// </remarks>
	[HttpPost]
	public async Task<IActionResult> AddToPurchaseQueue(PurchaseQueueDto purchaseQueueDto)
	{
		var purchaseQueue = new PurchaseQueue
		{
			Id = purchaseQueueDto.Id,
			ProductId = purchaseQueueDto.ProductId,
			Quantity = purchaseQueueDto.Quantity
		};

		await _purchaseQueueService.AddToPurchaseQueueAsync(purchaseQueue);
		return CreatedAtAction(nameof(GetPurchaseQueueById), new { id = purchaseQueue.Id }, purchaseQueueDto);
	}

	/// <summary>
	/// Gets a specific purchase queue item by its ID.
	/// </summary>
	/// <param name="id">The ID of the purchase queue item.</param>
	/// <returns>The requested purchase queue item.</returns>
	/// <response code="200">Returns the purchase queue item.</response>
	/// <response code="404">If the item is not found.</response>
	/// <remarks>
	/// Sample request:
	///
	///     GET /api/purchasequeue/abcd1234-5678-90ef-1234-567890abcdef
	///
	/// </remarks>
	[HttpGet("{id}")]
	public async Task<IActionResult> GetPurchaseQueueById(int id)
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

	/// <summary>
	/// Removes a purchase queue item by its ID.
	/// </summary>
	/// <param name="id">The ID of the purchase queue item to remove.</param>
	/// <returns>No content.</returns>
	/// <response code="204">Indicates the item was successfully deleted.</response>
	/// <response code="404">If the item is not found.</response>
	/// <remarks>
	/// Sample request:
	///
	///     DELETE /api/purchasequeue/abcd1234-5678-90ef-1234-567890abcdef
	///
	/// </remarks>
	[HttpDelete("{id}")]
	public async Task<IActionResult> RemoveFromPurchaseQueue(int id)
	{
		await _purchaseQueueService.RemoveFromPurchaseQueueAsync(id);
		return NoContent();
	}
}
