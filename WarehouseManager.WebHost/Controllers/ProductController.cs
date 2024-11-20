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

	/// <summary>
	/// Retrieves a list of all products.
	/// </summary>
	/// <returns>List of ProductDto objects.</returns>
	/// <response code="200">Returns the list of products.</response>
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

	/// <summary>
	/// Creates a new product.
	/// </summary>
	/// <param name="productDto">ProductDto object containing the product details.</param>
	/// <returns>ProductDto object of the created product.</returns>
	/// <response code="201">Returns the created product.</response>
	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
	{
		var product = new Product
		{
			Id = productDto.Id,
			Name = productDto.Name,
			Stock = productDto.Stock,
			Price = productDto.Price,
			IsInPurchaseQueue = productDto.IsInPurchaseQueue
		};
		await _productService.AddProductAsync(product);
		return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, productDto);
	}

	/// <summary>
	/// Retrieves a product by its ID.
	/// </summary>
	/// <param name="id">Product ID.</param>
	/// <returns>ProductDto object with the specified ID.</returns>
	/// <response code="200">Returns the product.</response>
	/// <response code="404">If the product is not found.</response>
	[HttpGet("{id}")]
	public async Task<IActionResult> GetProductById(int id)
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

	/// <summary>
	/// Updates an existing product.
	/// </summary>
	/// <param name="id">Product ID.</param>
	/// <param name="productDto">ProductDto object containing updated product details.</param>
	/// <response code="204">If the product was successfully updated.</response>
	/// <response code="404">If the product is not found.</response>
	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
	{
		var product = await _productService.GetProductByIdAsync(id);
		if (product == null) return NotFound();

		product.Name = productDto.Name;
		product.Stock = productDto.Stock;
		product.Price = productDto.Price;
		product.IsInPurchaseQueue = productDto.IsInPurchaseQueue;

		await _productService.UpdateProductAsync(product);
		return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
	}

	/// <summary>
	/// Deletes a product by its ID.
	/// </summary>
	/// <param name="id">Product ID.</param>
	/// <response code="204">If the product was successfully deleted.</response>
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteProduct(int id)
	{
		await _productService.DeleteProductAsync(id);
		return NoContent();
	}
}