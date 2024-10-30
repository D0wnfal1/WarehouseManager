using Microsoft.AspNetCore.Mvc;
using WarehouseManager.BusinessLogic.Services;
using WarehouseManager.DataAccess.Models;
using WarehouseManager.WebHost.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet]
	public async Task<IActionResult> GetProducts()
	{
		var products = await _productService.GetAllProductsAsync();
		return Ok(products.Select(p => new ProductDto
		{
			Id = p.Id,
			Name = p.Name,
			Stock = p.Stock,
			Price = p.Price,
			IsInPurchaseQueue = p.IsInPurchaseQueue
		}));
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
	{
		var product = new Product
		{
			Id = Guid.NewGuid(),
			Name = productDto.Name,
			Stock = productDto.Stock,
			Price = productDto.Price,
			IsInPurchaseQueue = productDto.IsInPurchaseQueue
		};

		await _productService.AddProductAsync(product);
		return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, productDto);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetProductById(Guid id)
	{
		var product = await _productService.GetProductByIdAsync(id);
		if (product == null) return NotFound();

		var productDto = new ProductDto
		{
			Id = product.Id,
			Name = product.Name,
			Stock = product.Stock,
			Price = product.Price,
			IsInPurchaseQueue = product.IsInPurchaseQueue
		};

		return Ok(productDto);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
	{
		var product = await _productService.GetProductByIdAsync(id);
		if (product == null) return NotFound();

		product.Name = productDto.Name;
		product.Stock = productDto.Stock;
		product.Price = productDto.Price;
		product.IsInPurchaseQueue = productDto.IsInPurchaseQueue;

		await _productService.UpdateProductAsync(product);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteProduct(Guid id)
	{
		await _productService.DeleteProductAsync(id);
		return NoContent();
	}
}
